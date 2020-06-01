using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jump
{
    public class ResourcesAwake : MonoBehaviour
    {
        void Awake()
        {
            LoadPrefabs();
            LoadResources();
        }

        private void LoadPrefabs()
        {
            var playerPrefab = Resources.Load("Player") as GameObject;
            var player = Instantiate(playerPrefab);
            player.name = "Player";

            var boxPrefab = Resources.Load("Box") as GameObject;
            var box = Instantiate(boxPrefab);
            box.name = "Box1";
        }

        private void LoadResources()
        {
            JumpResources.Awake();
            Debug.Log("JumpResoureces Loaded.");
        }
    }
}
