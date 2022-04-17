using System;
using System.Collections.Generic;
using System.Linq;
using Project.Scripts.GamePlay.Cube.Data.Faces;

namespace Project.Scripts.GamePlay.Cube.Data.Face
{
    public static class FaceTypeConverter
    {
        public static Type ConvertToType(this FaceType type)
        {
            switch (type)
            {
                case FaceType.FireDD: return typeof(BaseFace);
                default: return null;
            }
        }
        
        public static IEnumerable<Type> ConvertToType(this IEnumerable<FaceType> types)
        {
            return types.Select(ConvertToType).ToList();
        }
    }
}