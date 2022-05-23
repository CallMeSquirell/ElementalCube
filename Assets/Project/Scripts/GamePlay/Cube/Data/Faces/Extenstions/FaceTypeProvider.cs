using System;
using Project.Scripts.GamePlay.Cube.Data.Faces.Impl;

namespace Project.Scripts.GamePlay.Cube.Data.Faces.Extenstions
{
    public static class FaceTypeProvider
    {
        public static Type ConvertToType(this Bonus type)
        {
            switch (type)
            {
                default: return typeof(ElementalFace);
            }
        }
    }
}