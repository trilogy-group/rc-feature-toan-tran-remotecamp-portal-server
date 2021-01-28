using System;
using Moq;

namespace RemoteCamp.Portal.Core.Test.Common
{
    public interface IMockServiceProvider : IServiceProvider
    {
        Mock<TObject> GetMock<TObject>() where TObject : class;

        void SetInstance<TInterface>(TInterface instance);
    }
}