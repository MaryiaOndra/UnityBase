using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityBase.AngryBirds
{
    public class BirdController : MonoBehaviour
    {
        [SerializeField] GameObject birdPrefab;
        [SerializeField] Text pastCounter;

        GameObject createdBird;
        float delay = 1f;
        float remainingTime;
        int pastBirds;

        Action timerEndAction;

        void Start()
        {
            CreateBird();
        }

        void Update()
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                if (remainingTime <= 0)
                {
                    remainingTime = 0;
                    timerEndAction.Invoke();
                }
            }

            if (createdBird == null)
            {
                CreateBird();
            }
        }

        public void CatchBall()
        {
            LevelController levelController = GameObject.FindObjectOfType<LevelController>();
            StartTimer(delay / 2, levelController.CreateNewLevel);
            pastBirds = 0;
            pastCounter.text = pastBirds.ToString();
        }

        public void CreateNextBird()
        {
            StartTimer(delay, CreateBird);

            pastBirds++;
            pastCounter.text = pastBirds.ToString();
        }

        private void CreateBird()
        {
            createdBird = Instantiate(birdPrefab, gameObject.transform);
        }

        void StartTimer(float time, Action action)
        {
            remainingTime = time;
            timerEndAction = action;
        }
    }
}