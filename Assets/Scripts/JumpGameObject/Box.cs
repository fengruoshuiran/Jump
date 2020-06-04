using System;
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
        public const float NoneAlpha = 0F;

        public Box(GameObject boxGameObject, float a, float b, bool dir) : base(boxGameObject, a, b)
        {
            JumpResources.boxCreated++;
            SetBoxInitSettings();
            ChangeAlphaColorHalf();

            direction = dir;
        }

        public void SetBoxInitSettings()
        {
            // Put new box behind currentBox
            gameObject.GetComponent<Renderer>().sortingOrder--;
            // Draw new box random color
            SetRandomColor();
            SetAlphaColorNone();

            Rename($"Box{JumpResources.boxCreated}");

        }

        public void SetRandomColor()
        {
            SetRandomLightColor();
        }

        public void SetAlphaColorNone()
        {
            var color = gameObject.GetComponent<SpriteRenderer>().color;

            gameObject.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, NoneAlpha);
        }

        public void Death()
        {
            gameObject.GetComponent<FadeSprite>().FadeOutToDeath();
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

        public void ChangeAlphaColorNone()
        {
            ChangeAlphaColor(NoneAlpha);
        }

        public void ChangeAlphaColor(float newAlpha)
        {
            var nowAlpha = gameObject.GetComponent<SpriteRenderer>().color.a;
            var fadeSprite = gameObject.GetComponent<FadeSprite>();

            if (nowAlpha > newAlpha)
            {
                fadeSprite.FadeOut(nowAlpha, newAlpha);
            }
            else // nowAlpha < newAlpha
            {
                fadeSprite.FadeIn(nowAlpha, newAlpha);
            }

        }

        public void Rename(string newName)
        {
            gameObject.name = newName;
        }
    }
}
