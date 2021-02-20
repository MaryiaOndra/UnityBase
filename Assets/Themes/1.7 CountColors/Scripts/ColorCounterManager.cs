using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UnityBase.CountColors
{
    [RequireComponent(typeof(Generator))]
    public class ColorCounterManager : MonoBehaviour
    {
        [SerializeField] Text mistakeTxt;
        [SerializeField] Text restartTxt;
        Figure[] generatedFigures;

        int[] colorAmountsArray;
        int redAmount;
        int yellowAmount;
        int blueAmount;
        int greenAmount;
        int countMistakes;
        int countRightAnswers;

        public int MaxAmountColorIndex { get; private set; }
        public int TwinMaxAmountColorIndex { get; private set; }

        private void Awake()
        {
            Cursor.visible = true;        
        }

        void Start()
        {
            generatedFigures = GetComponent<Generator>().GeneratedFigures;
            CountColorAmount();
            FindMaxColorAmount();
        }

        void CountColorAmount() 
        {
            redAmount = 0;
            yellowAmount = 0;
            blueAmount = 0;
            greenAmount = 0;

            foreach (var figure in generatedFigures)
            {
                if (figure.isActiveAndEnabled)
                {
                    int _colorInt = figure.ActiveColorInt;

                    if (_colorInt.Equals((int)FigureColor.Red))
                    {
                        redAmount++;
                    }
                    else if (_colorInt.Equals((int)FigureColor.Green))
                    {
                        greenAmount++;
                    }
                    else if (_colorInt.Equals((int)FigureColor.Blue))
                    {
                        blueAmount++;
                    }
                    else if (_colorInt.Equals((int)FigureColor.Yellow))
                    {
                        yellowAmount++;
                    }
                }
            }
        }

        void FindMaxColorAmount() 
        {
            colorAmountsArray = new int[] { redAmount, yellowAmount, blueAmount, greenAmount };
            int _maxValue = colorAmountsArray.Max();

            if (ContainsDuplicates(colorAmountsArray))
            {
                restartTxt.text = "MIX COLORS";
                StartCoroutine("Restart");
            }
            
            CompareValueWithColor(_maxValue);
        }

        void CompareValueWithColor(int maxValue) 
        {
            int _colorIndex = 0;
            int _coundDouble = 0;

            foreach (var item in colorAmountsArray)
            {
                if (item == maxValue)
                {
                    _coundDouble++;
                }
            }

            if (maxValue.Equals(redAmount))
            {
                _colorIndex = (int)FigureColor.Red;
            }
            else if (maxValue.Equals(yellowAmount))
            {
                _colorIndex = (int)FigureColor.Yellow;
            }
            else if (maxValue.Equals(blueAmount))
            {
                _colorIndex = (int)FigureColor.Blue;
            }
            else if (maxValue.Equals(greenAmount))
            {
                _colorIndex = (int)FigureColor.Green;
            }            

            MaxAmountColorIndex = _colorIndex;
        }

        public void RightAnswerAction(Button activBtn) 
        {
            foreach (var figure in generatedFigures)
            {
                if (figure.isActiveAndEnabled && figure.ActiveColorInt.Equals(MaxAmountColorIndex))
                {
                    figure.HideFigure();
                }
            }

            activBtn.interactable = false;
            countRightAnswers++;

            FindAnotherColor();
        }

        public void WrongAnswerAction() 
        {
            countMistakes++;
            mistakeTxt.text = countMistakes.ToString();
        }

        void FindAnotherColor() 
        {
            int _maxAnswersInt = (int)FigureColor.Lenght - 1; 

            if (countRightAnswers < _maxAnswersInt)
            {
                CountColorAmount();
                FindMaxColorAmount();
            }
            else
            {
                restartTxt.text = "YOU FINISHED";
                StartCoroutine("Restart");
            }
        }

        IEnumerator Restart() 
        {
            yield return new WaitForSeconds(0.5f);
            
            string _activeSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(_activeSceneName);
        }

        bool ContainsDuplicates(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j] && array[i] != 0)
                        return true;
                }
            }
            return false;
        }
    }
}
