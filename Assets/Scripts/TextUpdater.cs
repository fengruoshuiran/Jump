using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Jump
{
    public class TextUpdater : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            UpdateScore();
        }

        public void UpdateScore()
        {
            GetComponent<Text>().text = JumpResources.score.ToString();
        }
    }
}
