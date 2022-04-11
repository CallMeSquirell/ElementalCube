using UnityEngine;

namespace Project.Scripts.Framework.Extensions
{
    public static class ObjectExtensions
    {
        public static bool NonNull(this Object obj)
        {
            return !ReferenceEquals(obj, null);
        }
    }
}