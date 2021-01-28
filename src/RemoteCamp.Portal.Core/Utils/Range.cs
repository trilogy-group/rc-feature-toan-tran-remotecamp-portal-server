using System;
using System.Collections.Generic;

namespace RemoteCamp.Portal.Core.Utils
{
    public class Range<TValue> : IEquatable<Range<TValue>>
        where TValue : IComparable<TValue>
    {
        public TValue From { get; }
        public TValue To { get; }

        public Range()
        {
            
        }

        public Range(TValue from, TValue to)
        {
            From = from;
            To = to;
        }

        public bool Equals(Range<TValue> other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return EqualityComparer<TValue>.Default.Equals(From, other.From) && EqualityComparer<TValue>.Default.Equals(To, other.To);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((Range<TValue>)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<TValue>.Default.GetHashCode(From) * 397) ^ EqualityComparer<TValue>.Default.GetHashCode(To);
            }
        }
    }
}
