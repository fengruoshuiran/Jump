using System;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Jump
{
    public class JumpChecker : MonoBehaviour
    {

        private PlayerControl playerControl;
        private MoveCamera moveCamera;

        private int counter;

        private const float jumpRate = Setting.Rate * 0.01F;
        private const float MaxJumpDistance = Setting.Rate * 15F;

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
                }
                else if (counter != 0)
                {
                    float jumpDistence = Mathf.Min(jumpRate * counter, MaxJumpDistance);

                    if (JumpResources.boxList[JumpResources.nextBox].direction == Setting.Adirection)
                    {
                        playerControl.JumpByABVector(jumpDistence, 0);
                    }
                    else // BoxStore.BoxList[NextBox].direction == Setting.Bdirection
                    {
                        playerControl.JumpByABVector(0, jumpDistence);
                    }
                    counter = 0;
                }
                else
                {
                    if (IsOnCurrentBox())
                    {

                    }
                    else if (IsOnNextBox())
                    {
                        JumpResources.score++;

                        JumpResources.trashBoxList.Add(JumpResources.boxList[JumpResources.currentBox]);
                        JumpResources.boxList.RemoveAt(JumpResources.currentBox);

                        moveCamera.MoveByABPoint(JumpResources.player.A, JumpResources.player.B);
                    }
                    else
                    {
                        if (!Setting.isCheat) SceneManager.LoadScene("Jump");
                    }
                }
            }
        }


        private bool IsOnCurrentBox()
        {
            return IsOnBox(JumpResources.currentBox);
        }

        private bool IsOnNextBox()
        {
            return IsOnBox(JumpResources.nextBox);
        }


        private bool IsOnBox(int boxId)
        {
            playerControl.UpdateOffsetByBoxId(boxId);
            var IsOnAVector = Math.Abs(JumpResources.player.OffsetA) < JumpResources.MaxPlayerOffsetOnBoxA;
            var IsOnBVector = Math.Abs(JumpResources.player.OffsetB) < JumpResources.MaxPlayerOffsetOnBoxB;

            //Debug.Log($"{IsOnAVector}, {IsOnBVector}");

            if (IsOnAVector && IsOnBVector) return true;
            else return false;
        }
    }
}
