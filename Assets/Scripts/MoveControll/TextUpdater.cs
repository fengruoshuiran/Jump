using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Jump
{
    public class TextUpdater : MonoBehaviour
    {
        private int preScore;

        private GameObject scoreText;
        private GameObject addScoreText;

        private Vector3 DefaultAddScoreTextPosition = new Vector2(0, 100);
        private Vector4 DefaultAddScoreTextColor = Color.white;

        private int leftFloatingTime = 0;
        private bool isFloating = false;

        private const float FloatDistance = 200;
        private const float FloatPerFrame = FloatDistance / Setting.MoveTime;
        private const float colorAPerFrame = 1.0F / Setting.MoveTime;

        // Start is called before the first frame update
        void Start()
        {
            preScore = JumpResources.score;

            scoreText = GameObject.Find("/Canvas/ScoreText");

            addScoreText = GameObject.Find("/Canvas/AddScoreText");

            UpdateScore();
            ResetAddScoreText("");
        }

        // Update is called once per frame
        void Update()
        {
            if (JumpResources.score != preScore)
            {
                UpdateScore();
                AddScoreTextRender(JumpResources.score - preScore);

                preScore = JumpResources.score;
            }

            if (isFloating)
            {
                if (leftFloatingTime == 0)
                {
                    ClearAddScoreText();
                    isFloating = false;
                }
                else
                {
                    FloatAddScoreText();
                    leftFloatingTime--;
                }
            }
        }

        public void UpdateScore()
        {
            scoreText.GetComponent<Text>().text = JumpResources.score.ToString();
        }

        private void AddScoreTextRender(int deltaScore)
        {
            ResetAddScoreText($"+ {deltaScore}");
            AddScoreTextFloatStart();
        }

        private void ResetAddScoreText(string text)
        {
            addScoreText.GetComponent<RectTransform>().anchoredPosition = DefaultAddScoreTextPosition;
            addScoreText.GetComponent<Text>().color = DefaultAddScoreTextColor;
            addScoreText.GetComponent<Text>().text = text;
        }

        private void ClearAddScoreText()
        {
            addScoreText.GetComponent<Text>().text = "";
        }

        private void AddScoreTextFloatStart()
        {
            leftFloatingTime = Setting.MoveTime;
            isFloating = true;
        }

        private void FloatAddScoreText()
        {
            var position = addScoreText.GetComponent<RectTransform>().anchoredPosition;
            var color = addScoreText.GetComponent<Text>().color;

            addScoreText.GetComponent<RectTransform>().anchoredPosition = new Vector2(position.x, position.y + FloatPerFrame);
            addScoreText.GetComponent<Text>().color = new Vector4(color.r, color.g, color.b, color.a - colorAPerFrame);
        }
    }
}
