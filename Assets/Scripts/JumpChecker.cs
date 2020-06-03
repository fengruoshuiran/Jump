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
        private int jumpFreeTime;
        private int konamiCommandCounter;

        private const int MaxPerfectJumpTime = Setting.MoveTime * 2;

        private const float MaxPlayerOffsetOnBoxA = 1.851013236F;
        private const float MaxPlayerOffsetOnBoxB = 1.851013236F;

        // Start is called before the first frame update
        void Start()
        {
            playerControl = JumpResources.player.gameObject.GetComponent<PlayerControl>();
            moveCamera = JumpResources.mainCamera.gameObject.GetComponent<MoveCamera>();

            counter = 0;
            jumpFreeTime = 0;
            konamiCommandCounter = 0;
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
                    PlayerJump();
                }
                else
                {
                    jumpFreeTime++;
                }

                JumpBoxCheck();
            }
            else
            {
                jumpFreeTime++;
            }

            if (counter == 0)
            {
                if (JumpResources.player.CanGettingThinner()) JumpResources.player.GettingThinner();
            }

            KonamiCommand();

            //Debug.Log(jumpFreeTime);
        }

        private void PlayerJump()
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

        private void JumpBoxCheck()
        {
            if (IsOnCurrentBox()) { }
            else if (IsOnNextBox())
            {
                if (JumpResources.score == 0)
                {
                    JumpResources.scoreRate = Setting.defaultScoreRate;
                }
                else if (jumpFreeTime < MaxPerfectJumpTime)
                {
                    JumpResources.scoreRate++;
                }
                else
                {
                    JumpResources.scoreRate = Setting.defaultScoreRate;
                }
                jumpFreeTime = 0;

                JumpResources.score += JumpResources.scoreRate;
                JumpResources.TrashOldBox();

                moveCamera.MoveByABPoint(JumpResources.player.A, JumpResources.player.B);
            }
            else
            {
                if (!Setting.isCheat) SceneManager.LoadScene("Jump");
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

        private void KonamiCommand()
        {
            if (Input.GetKeyDown(KonamiCommandCheckMap()))
            {
                konamiCommandCounter++;
                if (konamiCommandCounter == 10) Setting.isCheat = true;
            }
            else if (Input.anyKeyDown)
            {
                konamiCommandCounter = 0;
            }
        }

        private KeyCode KonamiCommandCheckMap()
        {
            if (konamiCommandCounter == 0 || konamiCommandCounter == 1)
            {
                // up
                return KeyCode.JoystickButton15;
            }
            else if (konamiCommandCounter == 2 || konamiCommandCounter == 3)
            {
                // down
                return KeyCode.Joystick1Button12;
            }
            else if (konamiCommandCounter == 4 || konamiCommandCounter == 6) {
                // left
                return KeyCode.JoystickButton14;
            }
            else if (konamiCommandCounter == 5 || konamiCommandCounter == 7)
            {
                // right
                return KeyCode.Joystick1Button13;
            }
            else if (konamiCommandCounter == 8)
            {
                // B
                return KeyCode.Joystick1Button0;
            }
            else
            {
                // A
                return KeyCode.Joystick1Button1;
            }
        }
    }
}
