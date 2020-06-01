using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jump
{
    public class MainCamera : JumpGameObject
    {
        private Vector3 defaultMainCameraPoint = new Vector3(0, 0, -10);
        public MainCamera(GameObject maincamera) : base(maincamera, 0, 0)
        {
            SetABVector(0, 0);
        }

        public new void AddABVector(float a, float b)
        {
            float setA = A + a;
            float setB = B + b;
            SetABVector(setA, setB);
        }

        public new void SetABVector(float a, float b)
        {
            A = a;
            B = b;
            gameObject.transform.position = Transformation.ABVectorToWorldPointForMainCamera(a, b);
        }
    }
}
