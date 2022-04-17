using System;
using System.Collections.Generic;

namespace Project.Scripts.Framework
{
    public class EnumComparator : IEqualityComparer<Enum>
    {
        public bool Equals(Enum x, Enum y)
        {
            if (x == null || y == null)
            {
                return false;
            }
            
            if (x.GetType() != y.GetType())
            {
                return false;
            }

            return x.Equals(y);
        }

        public int GetHashCode(Enum obj)
        {
            return obj.GetHashCode();
        }
    }
}