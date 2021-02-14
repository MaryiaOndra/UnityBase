using UnityEngine;

namespace UnityBase.CountColors
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Figure : MonoBehaviour
    {
        SpriteRenderer figureSprtRndr;

        public int ActiveColorInt { get; private set; }

        void Awake()
        {
            figureSprtRndr = GetComponent<SpriteRenderer>();
            SetRandomColor();
        }

        void SetRandomColor()
        {
            int _colorIndx = Random.Range(0, (int)FigureColor.Lenght);

            switch (_colorIndx)
            {
                case (int)FigureColor.Red:
                    figureSprtRndr.color = Color.red;
                    ActiveColorInt = (int)FigureColor.Red;
                    break;
                case (int)FigureColor.Blue:
                    figureSprtRndr.color = Color.blue;
                    ActiveColorInt = (int)FigureColor.Blue;
                    break;
                case (int)FigureColor.Yellow:
                    figureSprtRndr.color = Color.yellow;
                    ActiveColorInt = (int)FigureColor.Yellow;
                    break;
                case (int)FigureColor.Green:
                    figureSprtRndr.color = Color.green;
                    ActiveColorInt = (int)FigureColor.Green;
                    break;
            }
        }

        public void HideFigure() 
        {
            gameObject.SetActive(false);
        }
    }

    enum FigureColor 
    {
        Red,
        Yellow,
        Green,
        Blue,
        Lenght
    }
}
