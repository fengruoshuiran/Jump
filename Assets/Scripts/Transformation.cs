using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jump
{
    public static class Transformation
    {
        private const float OffsetAUnitVectorInWorldPointX = 0.958934256F;
        private const float OffsetAUnitVectorInWorldPointY = 0.283628442F; 

        private const float OffsetBUnitVectorInWorldPointX = -0.958934256F;
        private const float OffsetBUnitVectorInWorldPointY = 0.283628442F;
        public static Vector3 ABVectorToWorldPoint(float x, float y)
        {
            return new Vector3(OffsetAUnitVectorInWorldPointX * x + OffsetBUnitVectorInWorldPointX * y
                , OffsetAUnitVectorInWorldPointY * x + OffsetBUnitVectorInWorldPointY * y, 0);
        }

        public static Vector3 ABVectorToWorldPointForMainCamera(float x, float y)
        {
            return new Vector3(OffsetAUnitVectorInWorldPointX * x + OffsetBUnitVectorInWorldPointX * y
                , OffsetAUnitVectorInWorldPointY * x + OffsetBUnitVectorInWorldPointY * y, -10);
        }

        public static Vector2 YVectorToABVector(float y)
        {
            return new Vector2(OffsetAUnitVectorInWorldPointY * y, OffsetBUnitVectorInWorldPointY * y);
        }
    }
}
