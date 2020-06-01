using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jump
{
    public class Box : JumpGameObject
    {
        public bool direction;
        public const bool directionA = true;
        public const bool directionB = false;
        public Box(GameObject boxGameObject, float a, float b, bool dir) : base(boxGameObject, a, b)
        {
            direction = dir;
        }
    }
}
