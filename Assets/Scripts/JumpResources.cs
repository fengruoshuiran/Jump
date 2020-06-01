using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jump
{
    public static class JumpResources
    {
        public static List<Box> boxList;
        public static List<Box> trashBoxList;
        public static Player player;
        public static MainCamera mainCamera;

        public static int score;

        public static int boxCreated ;

        public const int CurrentBox = 0;
        public const int NextBox = 1;
        public static int lastBox
        {
            get { return boxList.Count - 1; }
        }

        public const int MaxBoxCount = 10;

        public const float MaxPlayerOffsetOnBoxA = 1.851013236F;
        public const float MaxPlayerOffsetOnBoxB = 1.851013236F;

        public static void Awake()
        {
            boxList = new List<Box>();
            trashBoxList = new List<Box>();
            player = new Player(GameObject.Find("Player"));

            score = 0;

            boxCreated = 0;

            mainCamera = new MainCamera(GameObject.Find("Main Camera"));

            Application.targetFrameRate = 60;
        }
    }
}
