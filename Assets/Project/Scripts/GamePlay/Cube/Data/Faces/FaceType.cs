using System;
using UnityEngine;

namespace Project.Scripts.GamePlay.Cube.Data.Faces
{
    [Serializable]
    public class FaceType
    {
        [SerializeField] private Bonus _bonus;
        [SerializeField] private Element _element;

        public Bonus Bonus => _bonus;
        public Element Element => _element;
    }

    public enum Bonus
    {
        Empty,
        Crit,
        Dot,
    }
    
    public enum Element
    {
        Empty,
        Piro,
        Electro,
        Krio,
    }
}