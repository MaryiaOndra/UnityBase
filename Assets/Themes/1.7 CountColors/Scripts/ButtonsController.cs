using UnityEngine;
using UnityEngine.UI;

namespace UnityBase.CountColors
{
    public class ButtonsController : MonoBehaviour
    {
        [SerializeField] GameObject buttonPrefab;

        void Start()
        {
            CreateButtons();
        }

        void CreateButtons() 
        {
            for (int i = 0; i < (int)FigureColor.Lenght; i++)
            {
                var _button = Instantiate(buttonPrefab, transform);
                Image _buttonImage = _button.GetComponent<Image>();
                ButtonBhv _activeBtn = _button.GetComponent<ButtonBhv>();

                switch (i)
                {
                    case (int)FigureColor.Blue:
                        _buttonImage.color = Color.blue;
                        _activeBtn.BtnColorIndex = (int)FigureColor.Blue;
                        break;
                    case (int)FigureColor.Red:
                        _buttonImage.color = Color.red;
                        _activeBtn.BtnColorIndex = (int)FigureColor.Red;
                        break;
                    case (int)FigureColor.Yellow:
                        _buttonImage.color = Color.yellow;
                        _activeBtn.BtnColorIndex = (int)FigureColor.Yellow;
                        break;
                    case (int)FigureColor.Green:
                        _buttonImage.color = Color.green;
                        _activeBtn.BtnColorIndex = (int)FigureColor.Green;
                        break;
                }
            }
        }
    }
}