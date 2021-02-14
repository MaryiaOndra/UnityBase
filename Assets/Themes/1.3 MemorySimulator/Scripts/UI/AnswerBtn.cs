using UnityEngine;
using UnityEngine.UI;

namespace UnityBase.MemorySimulator
{
    public class AnswerBtn : MonoBehaviour
    {
        [SerializeField] private FiguresManager figuresManager;
        [SerializeField] private Text rightAnswerText;
        [SerializeField] private Text wrongAnswerText;

        private int rightAnswersCount;
        private int wrongAnswersCount;

        private Button[] answerButtons;

        private void Awake()
        {
            answerButtons = GetComponentsInChildren<Button>();
        }

        private void Update()
        {
            SetBtnInteractable();
            WriteTextAnswers();
        }

        private void WriteTextAnswers()
        {
            rightAnswerText.text = rightAnswersCount.ToString();
            wrongAnswerText.text = wrongAnswersCount.ToString();
        }

        private void SetBtnInteractable()
        {
            Vector3 workPrefabPos = figuresManager.WorkPrefab.transform.position;

            if (!workPrefabPos.Equals(Vector3.zero))
            {
                foreach (var btn in answerButtons)
                    btn.interactable = false;
            }
            else
            {
                foreach (var btn in answerButtons)
                    btn.interactable = true;
            }
        }

        public void CheckAnswer(string answer)
        {
            int answerInt = figuresManager.AnswerCounterInt;
            Debug.Log("ANSWER" + answerInt);

            switch (answer)
            {
                case "yes":
                    if (answerInt.Equals(3))
                        rightAnswersCount++;
                    else
                        wrongAnswersCount++;
                    break;

                case "similar":
                    if (answerInt.Equals(1) || answerInt.Equals(2))
                        rightAnswersCount++;
                    else
                        wrongAnswersCount++;
                    break;

                case "no":
                    if (answerInt.Equals(0))
                        rightAnswersCount++;
                    else
                        wrongAnswersCount++;
                    break;
            }
        }
    }
}
