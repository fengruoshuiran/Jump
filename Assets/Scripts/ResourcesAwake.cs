using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jump
{
    public class ResourcesAwake : MonoBehaviour
    {
        private void Awake()
        {
            LoadPrefabs();
            LoadResources();
        }

        private void LoadPrefabs()
        {
            var playerPrefab = Resources.Load("Prefabs/Player") as GameObject;
            var player = Instantiate(playerPrefab);
            player.name = "Player";

            var boxPrefab = Resources.Load("Prefabs/Box") as GameObject;
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
