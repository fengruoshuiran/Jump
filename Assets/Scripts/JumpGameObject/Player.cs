using UnityEngine;

namespace Jump
{
    public class Player : JumpGameObject
    {
        public float OffsetA;
        public float OffsetB;
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
    }
}
