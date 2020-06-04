using Jump;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

namespace Jump
{
    public class BoxCreater : MonoBehaviour
    {
        private const float MinBoxDistance = Setting.Rate * 5;
        private const float MaxBoxDistance = Setting.Rate * 10;

        private void Start()
        {
            GameObject currentBoxGameObject = GameObject.Find("/Box1");

            var currentBox = new Box(currentBoxGameObject, 0, 0, true);

            currentBox.ChangeAlphaColorFull();
            JumpResources.boxList.Add(currentBox);
        }

        private void Update()
        {
            if (JumpResources.boxList.Count < JumpResources.MaxBoxCount)
            {
                JumpResources.boxList.Add(CreatRandomBox());
            }
        }

        public Box CreatRandomBox()
        {
            var direction = Random.value > Random.value;
            var Offset = Random.Range(MinBoxDistance, MaxBoxDistance);

            if (direction == Setting.Adirection)
            {
                return CreateBoxByABOffset(Offset, 0, direction);
            }
            else // direction == Setting.Bdirection
            {
                return CreateBoxByABOffset(0, Offset, direction);
            }
        }
        public Box CreateBoxByABOffset(float OffsetA, float OffsetB, bool dir)
        {
            var lastBox = JumpResources.boxList[JumpResources.lastBox];
            var newBoxGameObject = Instantiate(lastBox.gameObject);
            var a = OffsetA + lastBox.A;
            var b = OffsetB + lastBox.B;
            var newBox = new Box(newBoxGameObject, a, b, dir);

            return newBox;
        }
    }
}
