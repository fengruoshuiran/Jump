﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jump
{
    public class MoveCamera : MonoBehaviour
    {
        private bool isSliding;
        private int leftMoveFrame;
        private float SlideAVectorPerFrame;
        private float SlideBVectorPerFrame;
        private float aimAPosition;
        private float aimBPosition;

        private const int MoveTime = Setting.AnimationTime;


        private void Update()
        {
            if (isSliding)
            {
                if (leftMoveFrame == 0)
                {
                    isSliding = false;
                    TeleportByABPoint(aimAPosition, aimBPosition);
                }
                else
                {
                    leftMoveFrame--;
                    JumpResources.mainCamera.AddABVector(SlideAVectorPerFrame, SlideBVectorPerFrame);
                }
            }
        }

        public void MoveByABPoint(float a, float b)
        {
            aimAPosition = a;
            aimBPosition = b;
            if (Setting.isTest)
            {
                TeleportByABPoint(a, b);
            }
            else
            {
                SlideByABPoint(a, b);
            }
        }

        // for test
        private void TeleportByABPoint(float a, float b)
        {
            JumpResources.mainCamera.SetABVector(a, b);
        }

        private void SlideByABPoint(float a, float b)
        {
            var currentMainCameraAPosition = JumpResources.mainCamera.A;
            var currentMainCameraBPosition = JumpResources.mainCamera.B;
            var aVector = a - currentMainCameraAPosition;
            var bVector = b - currentMainCameraBPosition;

            SlideStart(aVector, bVector);
        }

        private void SlideStart(float aVector, float bVector)
        {
            isSliding = true;
            leftMoveFrame = MoveTime;
            SlideAVectorPerFrame = aVector / leftMoveFrame;
            SlideBVectorPerFrame = bVector / leftMoveFrame;
        }
    }
}
