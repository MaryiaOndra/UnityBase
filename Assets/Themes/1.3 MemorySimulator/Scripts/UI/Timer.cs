using UnityEngine;
using UnityEngine.UI;

namespace UnityBase.MemorySimulator
{
    public class Timer : MonoBehaviour
    {
        private Text timerText;
        private float timeToDisplay;

        private void Awake()
        {
            timerText = GetComponent<Text>();
        }

        private void Update()
        {
            timeToDisplay = Time.timeSinceLevelLoad;
            DisplayTime(timeToDisplay);
        }

        void DisplayTime(float timeToDisplay)
        {
            timeToDisplay += 1;

            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
