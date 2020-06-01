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
        // Bad way to get gameobject
        private const float MinBoxDistance = Setting.Rate * 5;
        private const float MaxBoxDistance = Setting.Rate * 10;

        // Start is called before the first frame update
        void Start()
        {
            GameObject currentBoxGameObject = GameObject.Find("/Box1");

            var currentBox = new Box(currentBoxGameObject, 0, 0, true);
            JumpResources.boxCreated++;
            setBoxSettings(currentBox);
            JumpResources.boxList.Add(currentBox);
        }

        // Update is called once per frame
        void Update()
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
            var newBoxGameObject = GameObject.Instantiate(lastBox.gameObject);
            var a = OffsetA + lastBox.A;
            var b = OffsetB + lastBox.B;
            var newBox = new Box(newBoxGameObject, a, b, dir);
            // Waring: Maybe out of Range
            JumpResources.boxCreated++;

            setBoxSettings(newBox);

            return newBox;
        }

        private void setBoxSettings(Box box)
        {
            // Put new box behind currentBox
            box.gameObject.GetComponent<Renderer>().sortingOrder--;
            // Draw new box random color
            box.gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);

            box.gameObject.name = $"Box{JumpResources.boxCreated}";

        }
    }
}
