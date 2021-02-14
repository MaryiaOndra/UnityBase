using UnityEngine;
using UnityEngine.UI;

namespace UnityBase.CountColors
{
    [RequireComponent(typeof(Button))]
    public class ButtonBhv : MonoBehaviour
    {
        Button activeButton;
        int maxColorIndex;

        public int BtnColorIndex { get; set; }
        public bool IsRightColor { get; private set; }
        public bool IsWrongColor { get; private set; }

        void Start()
        {
            activeButton = GetComponent<Button>();
            activeButton.onClick.AddListener(CheckColor);
        }

        void CheckColor()
        {
            ColorCounterManager _colorCounter = GameObject.FindObjectOfType<ColorCounterManager>();
            maxColorIndex = _colorCounter.MaxAmountColorIndex;

            if (BtnColorIndex == maxColorIndex)
            {
                _colorCounter.RightAnswerAction(activeButton);
            }
            else
            {
                _colorCounter.WrongAnswerAction();
            }
        }
    }
}
