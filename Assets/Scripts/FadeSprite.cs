using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jump
{
    public class FadeSprite : MonoBehaviour
    {
        public bool isFading = false;

        private bool shouldDeath = false;
        private bool fadeState = FadeInState;
        private int leftFadeFrame = 0;

        private float minAlpha = 0F;
        private float maxAlpha = 0.5F;

        private const bool FadeInState = true;
        private const bool FadeOutState = false;

        private const int FadeTime = Setting.AnimationTime;

        private const float DefaultMinAlpha = 0F;
        private const float DefaultMaxAlpha = 0.5F;

        private void Update()
        {
            if (isFading)
            {
                if (leftFadeFrame != 0)
                {
                    if (fadeState == FadeInState)
                    {
                        FadeInPerFrame();
                    }
                    else // fadeState = FadeOutState
                    {
                        FadeOutPerFrame();
                    }
                    leftFadeFrame--;
                }
                else
                {
                    if (shouldDeath == true)
                    {
                        GameObject.Destroy(gameObject);
                    }

                    isFading = false;
                }
            }
        }

        public void SetMaxMinAlpha(float min, float max)
        {
            minAlpha = min;
            maxAlpha = max;
        }

        public void FadeIn(float minAlpha, float maxAlpha)
        {
            SetMaxMinAlpha(minAlpha, maxAlpha);
            FadeIn();
        }

        public void FadeIn()
        {
            FadeStart();
            fadeState = FadeInState;
        }
        public void FadeOut(float maxAlpha, float minAlpha)
        {
            SetMaxMinAlpha(minAlpha, maxAlpha);
            FadeOut();
        }

        public void FadeOut()
        {
            FadeStart();
            fadeState = FadeOutState;
        }

        public void FadeOutToDeath()
        {
            var maxAlpha = gameObject.GetComponent<SpriteRenderer>().color.a;
            var minAlpha = 0F;

            SetMaxMinAlpha(minAlpha, maxAlpha);
            FadeOutToDeathStart();
            shouldDeath = true;
        }


        private void FadeInPerFrame()
        {
            AddAColor(FadePerFrame());
        }

        private void FadeOutPerFrame()
        {
            AddAColor(-FadePerFrame());
        }

        private void FadeOutToDeathStart()
        {
            FadeStart();
            shouldDeath = true;
        }

        private void FadeStart()
        {
            isFading = true;
            leftFadeFrame = FadeTime;
        }

        private void SetAColor(float a)
        {
            var color = GetComponent<SpriteRenderer>().color;

            GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, a);
        }

        private void AddAColor(float a)
        {
            var color = GetComponent<SpriteRenderer>().color;

            GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, Math.Max(Math.Min(color.a + a, maxAlpha), minAlpha));
            //Debug.Log($"{name}: {GetComponent<SpriteRenderer>().color}");
        }

        private float FadePerFrame()
        {
            return (maxAlpha - minAlpha) / FadeTime;
        }
    }
}
