using System;
using Project.Scripts.GamePlay.Cube.Data.Faces;
using Project.Scripts.GamePlay.Cube.Data.Faces.Impl;

namespace Project.Scripts.GamePlay.Cube.Data.Face
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