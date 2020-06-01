using UnityEngine;

namespace Jump
{
    public class Player : JumpGameObject
    {
        public float OffsetA;
        public float OffsetB;

        private const float MinXScaleRate = 1;
        private const float MaxXScaleRate = MinXScaleRate + Setting.MaxPlayerScaleChangeRate;

        private const float ScaleFatterPerFrame = Setting.MaxPlayerScaleChangeRate / Setting.MaxJumpTime;
        private const float ScaleThinnerPerFrame = Setting.MaxPlayerScaleChangeRate / Setting.MaxRecoveryTime;

        public Player(GameObject boxGameObject) : base(boxGameObject)
        {
            OffsetA = 0;
            OffsetB = 0;
        }

        // This function is just for show the jump action, NEVER use to set player's position
        public void MoveByYVector(float y)
        {
            var ABVector = Transformation.YVectorToABVector(y);
            var a = ABVector.x;
            var b = ABVector.y;

            AddABVector(a, b);
        }

        public void SetPlayerInitSetting()
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);
        }


        public bool CanGettingFatter()
        {
            return gameObject.transform.localScale.x < MaxXScaleRate;
        }

        public bool CanGettingThinner()
        {
            return gameObject.transform.localScale.x > MinXScaleRate;
        }

        public void GettingFatter()
        {
            var localScale = gameObject.transform.localScale;

            if (localScale.x < MaxXScaleRate)
            {
                gameObject.transform.localScale = new Vector3(localScale.x + ScaleFatterPerFrame, localScale.y - ScaleFatterPerFrame, localScale.z);
            }
        }

        public void GettingThinner()
        {
            var localScale = gameObject.transform.localScale;

            if (localScale.x > MinXScaleRate)
            {
                gameObject.transform.localScale = new Vector3(localScale.x - ScaleThinnerPerFrame, localScale.y + ScaleThinnerPerFrame, localScale.z);
            }
        }
    }
}
