﻿using System;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Jump
{
    public class JumpChecker : MonoBehaviour
    {

        private PlayerControl playerControl;
        private MoveCamera moveCamera;
        private TextUpdater textUpdater;

        private int counter;

        private const float MaxPlayerOffsetOnBoxA = 1.851013236F;
        private const float MaxPlayerOffsetOnBoxB = 1.851013236F;

        // Start is called before the first frame update
        void Start()
        {
            playerControl = JumpResources.player.gameObject.GetComponent<PlayerControl>();
            moveCamera = JumpResources.mainCamera.gameObject.GetComponent<MoveCamera>();

            counter = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (!playerControl.ControlLock)
            {
                if (Input.GetKey(Setting.jumpKey))
                {
                    //Waring: Maybe out of range
                    counter++;

                    if (JumpResources.player.CanGettingFatter()) JumpResources.player.GettingFatter();
                }
                else if (counter != 0)
                {
                    float jumpDistence = Mathf.Min(Setting.jumpRate * counter, Setting.MaxJumpDistance);

                    if (JumpResources.boxList[JumpResources.NextBox].direction == Setting.Adirection)
                    {
                        playerControl.JumpByABVector(jumpDistence, 0);
                    }
                    else // BoxStore.BoxList[NextBox].direction == Setting.Bdirection
                    {
                        playerControl.JumpByABVector(0, jumpDistence);
                    }
                    counter = 0;
                }

                if (IsOnCurrentBox()) { }
                else if (IsOnNextBox())
                {
                    JumpResources.score++;
                    JumpResources.TrashOldBox();

                    moveCamera.MoveByABPoint(JumpResources.player.A, JumpResources.player.B);
                }
                else
                {
                    if (!Setting.isCheat) SceneManager.LoadScene("Jump");
                }
            }
            else if (counter == 0)
            {
                if (JumpResources.player.CanGettingThinner()) JumpResources.player.GettingThinner();
            }
        }


        private bool IsOnCurrentBox()
        {
            return IsOnBox(JumpResources.CurrentBox);
        }

        private bool IsOnNextBox()
        {
            return IsOnBox(JumpResources.NextBox);
        }


        private bool IsOnBox(int boxId)
        {
            playerControl.UpdateOffsetByBoxId(boxId);
            var IsOnAVector = Math.Abs(JumpResources.player.OffsetA) < MaxPlayerOffsetOnBoxA;
            var IsOnBVector = Math.Abs(JumpResources.player.OffsetB) < MaxPlayerOffsetOnBoxB;

            //Debug.Log($"{IsOnAVector}, {IsOnBVector}");

            if (IsOnAVector && IsOnBVector) return true;
            else return false;
        }
    }
}
