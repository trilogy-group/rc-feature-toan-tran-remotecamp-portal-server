using System;
using System.Collections.Concurrent;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace RemoteCamp.Portal.Core.Test.Common
{
    public class MockServiceProvider : IMockServiceProvider
    {
        private readonly ConcurrentDictionary<string, Mock> _createdMocks = new ConcurrentDictionary<string, Mock>();
        private readonly ConcurrentDictionary<string, object> _instances = new ConcurrentDictionary<string, object>();

        public object GetService(Type serviceType)
        {
            if (serviceType.IsInterface)
            {
                if (_instances.TryGetValue(serviceType.AssemblyQualifiedName, out var instance))
                {
                    return instance;
                }
                var mock = GetOrCreateMock(serviceType);
                return ((Mock)mock).Object;
            }

            return ActivatorUtilities.CreateInstance(this, serviceType);
        }

        public Mock<TObject> GetMock<TObject>() where TObject : class
        {
            return (Mock<TObject>)GetOrCreateMock(typeof(TObject));
        }

        public void SetInstance<TInterface>(TInterface instance)
        {
            _instances[typeof(TInterface).AssemblyQualifiedName] = instance;
        }

        private object GetOrCreateMock(Type serviceType)
        {
            return _createdMocks.GetOrAdd(serviceType.AssemblyQualifiedName, key =>
            {
                var genericType = typeof(Mock<>).MakeGenericType(serviceType);
                return (Mock)Activator.CreateInstance(genericType);
            });
        }
    }
}