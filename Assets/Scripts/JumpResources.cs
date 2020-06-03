using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Jump
{
    public static class JumpResources
    {
        public static List<Box> boxList;
        public static List<Box> trashBoxList;
        public static Player player;
        public static MainCamera mainCamera;

        public static int score;
        public static int scoreRate;

        public static int boxCreated ;

        public const int CurrentBox = 0;
        public const int NextBox = 1;
        public static int lastBox
        {
            get { return boxList.Count - 1; }
        }

        public const int MaxBoxCount = 10;

        public static void Awake()
        {
            boxList = new List<Box>();
            trashBoxList = new List<Box>();
            player = new Player(GameObject.Find("Player"));
            mainCamera = new MainCamera(GameObject.Find("Main Camera"));

            score = 0;
            scoreRate = Setting.defaultScoreRate;

            boxCreated = 0;

            Application.targetFrameRate = Setting.FrameRate;
        }

        public static void TrashOldBox()
        {
            boxList[JumpResources.CurrentBox].ChangeAlphaColorQuarter();
            boxList[JumpResources.NextBox].ChangeAlphaColorFull();

            trashBoxList.Add(JumpResources.boxList[JumpResources.CurrentBox]);
            boxList.RemoveAt(JumpResources.CurrentBox);
        }
    }
}
