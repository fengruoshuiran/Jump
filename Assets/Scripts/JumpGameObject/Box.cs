using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jump
{
    public class Box : JumpGameObject
    {
        public bool direction;
        public const bool DirectionA = true;
        public const bool DirectionB = false;

        public const float FullAlpha = 1F;
        public const float HalfAlpha = 0.5F;
        public const float QuarterAlpha = 0.25F;

        public Box(GameObject boxGameObject, float a, float b, bool dir) : base(boxGameObject, a, b)
        {
            direction = dir;
        }

        public void SetBoxInitSettings()
        {
            // Put new box behind currentBox
            gameObject.GetComponent<Renderer>().sortingOrder--;
            // Draw new box random color
            SetRandomColor();
            ChangeAlphaColorHalf();

            Rename($"Box{JumpResources.boxCreated}");

        }

        public void SetRandomColor()
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);
        }

        public void ChangeAlphaColorFull()
        {
            ChangeAlphaColor(FullAlpha);
        }

        public void ChangeAlphaColorHalf()
        {
            ChangeAlphaColor(HalfAlpha);
        }

        public void ChangeAlphaColorQuarter()
        {
            ChangeAlphaColor(QuarterAlpha);
        }

        public void ChangeAlphaColor(float alpha)
        {
            var color = gameObject.GetComponent<SpriteRenderer>().color;

            gameObject.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, alpha);
        }

        public void Rename(string newName)
        {
            gameObject.name = newName;
        }
    }
}
