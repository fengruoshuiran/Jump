using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jump
{
    public class ButtonStateChanger : MonoBehaviour
    {
        private GameObject backGround;

        private bool latePushStateFlag;

        private const bool PauseState = true;
        private const bool PlayState = false;

        private const float MinAlpha = 0F;
        private const float MaxAlpha = 0.5F;

        private void Start()
        {
            backGround = GameObject.Find("Canvas/GrayBackGround");
            GameStart();
        }

        private void Update()
        {
            if (JumpResources.isPause && Input.GetKeyDown(Setting.playKey))
            {
                Play();
            }
            else if (!JumpResources.isPause && Input.GetKeyDown(Setting.pauseKey))
            {
                Pause();
            }

            if (!IsFading() && latePushStateFlag == PlayState && JumpResources.isPause == true)
            {
                JumpResources.isPause = false;
            }
            if (latePushStateFlag == PauseState && JumpResources.isPause != true)
            {
                JumpResources.isPause = true;
            }
        }

            public void GameStart()
        {
            ChangeButtonSpriteToPlay();
            GetComponent<FadeSprite>().FadeIn(MinAlpha, MaxAlpha);
            backGround.GetComponent<FadeSprite>().FadeIn(MinAlpha, MaxAlpha);

            latePushStateFlag = PauseState;
        }

        public void Pause()
        {
            ChangeButtonSpriteToPause();
            GetComponent<FadeSprite>().FadeIn(MinAlpha, MaxAlpha);
            backGround.GetComponent<FadeSprite>().FadeIn(MinAlpha, MaxAlpha);

            latePushStateFlag = PauseState;
        }

        public void Play()
        {
            ChangeButtonSpriteToPlay();
            GetComponent<FadeSprite>().FadeOut(MaxAlpha, MinAlpha);
            backGround.GetComponent<FadeSprite>().FadeOut(MaxAlpha, MinAlpha);

            latePushStateFlag = PlayState;
        }

        private void ChangeButtonSpriteToPause()
        {
            var pauseButton = Resources.Load<Sprite>("Sprites/PauseButton");

            GetComponent<SpriteRenderer>().sprite = pauseButton;
        }

        private void ChangeButtonSpriteToPlay()
        {
            var playButton = Resources.Load<Sprite>("Sprites/PlayButton");

            GetComponent<SpriteRenderer>().sprite = playButton;
        }

        private bool IsFading()
        {
            return GetComponent<FadeSprite>().isFading;
        }
    }
}
