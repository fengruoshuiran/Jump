using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jump
{
    public class JumpGameObject
    {
        public GameObject gameObject;
        public float A;
        public float B;

        public JumpGameObject(GameObject jumpGameObject, float a, float b)
        {
            this.gameObject = jumpGameObject;
            SetABVector(a, b);
        }

        public JumpGameObject(GameObject jumpGameObject)
        {
            this.gameObject = jumpGameObject;
            A = 0;
            B = 0;
        }

        public void AddABVector(float a, float b)
        {
            float setA = A + a;
            float setB = B + b;
            SetABVector(setA, setB);
        }
        public void SetABVector(float a, float b)
        {
            A = a;
            B = b;
            gameObject.transform.position = Transformation.ABVectorToWorldPoint(a, b);
        }
    }
}
