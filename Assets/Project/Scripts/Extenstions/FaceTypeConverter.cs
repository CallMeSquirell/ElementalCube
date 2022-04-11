using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Scripts.GamePlay.Cube.Data.Face
{
    public static class FaceTypeConverter
    {
        public static Type Convert(this FaceType type)
        {
            switch (type)
            {
                case FaceType.FireDD: return typeof(BaseFace);
                default: return null;
            }
        }
        
        public static IEnumerable<Type> Convert(this IEnumerable<FaceType> types)
        {
            return types.Select(Convert).ToList();
        }
    }
}