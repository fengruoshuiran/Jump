using UnityEngine;

namespace Jump
{
    public class PlayerControl : MonoBehaviour
    {
        public bool ControlLock = false;

        private bool isJumping;
        private int leftMoveFrame;
        private int fullMoveFrame;
        private float slideAVectorPerFrame;
        private float slideBVectorPerFrame;
        private float aimAPosition;
        private float aimBPosition;

        // Start is called before the first frame update
        void Start()
        {
            ControlLock = false;

            setPlayerSetting(JumpResources.player.gameObject);
        }

        void Update()
        {
            if (isJumping)
            {
                if (leftMoveFrame == 0)
                {
                    isJumping = false;
                    ControlLock = false;
                    JumpResources.player.setABVector(aimAPosition, aimBPosition);
                    //Debug.Log($"{aimAPosition}, {aimBPosition}");
                }
                else
                {
                    JumpResources.player.addABVector(slideAVectorPerFrame, slideBVectorPerFrame);
                    JumpResources.player.MoveByYVector(getFloatHeightPerFrame());
                    leftMoveFrame--;
                }
            }
        }

        public void UpdateOffset()
        {
            UpdateOffsetByBoxId(JumpResources.currentBox);
        }

        public void UpdateOffsetByBoxId(int boxId)
        {
            JumpResources.player.OffsetA = JumpResources.player.A - JumpResources.boxList[boxId].A;
            JumpResources.player.OffsetB = JumpResources.player.B - JumpResources.boxList[boxId].B;
            //Debug.Log($"{ Resources.player.OffsetA}, { Resources.player.OffsetB}");
        }
        public void JumpByABVector(float a, float b)
        {
            aimAPosition = JumpResources.player.A + a;
            aimBPosition = JumpResources.player.B + b;

            if (Setting.isTest)
            {
                TeleportByABVector(a, b);
            }
            else
            {
                JumpStart();
                SlideStart(a, b);
                FloatStart();
            }
        }

        // For test
        private void TeleportByABVector(float a, float b)
        {
            JumpResources.player.addABVector(a, b);
        }

        private void JumpStart()
        {
            isJumping = true;
            ControlLock = true;
            leftMoveFrame = (int)Setting.MoveTime;
            fullMoveFrame = leftMoveFrame;
        }
        private void SlideStart(float aVector, float bVector)
        {
            slideAVectorPerFrame = aVector / leftMoveFrame;
            slideBVectorPerFrame = bVector / leftMoveFrame;
        }

        private void FloatStart()
        {

        }

        private float getFloatHeightPerFrame()
        {
            //Debug.Log($"{fullMoveFrame}, {leftMoveFrame}");
            return Setting.FloatVelocity * (1.0F - (fullMoveFrame - leftMoveFrame) * 2.0F / fullMoveFrame);
        }

        private void setPlayerSetting(GameObject player)
        {
            player.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);
        }
    }
}
