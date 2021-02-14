using UnityEngine;

namespace UnityBase.Calculator
{
    [RequireComponent(typeof(CanvasGroup))]
    public class SlideOutSideBar : MonoBehaviour
    {
        private CanvasGroup canvasGroup;
        private bool isShowed = false;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            Hide();
        }

        public void ClickButton()
        {
            if (!isShowed)
                Show();
            else
                Hide();
        }

        private void Show()
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1;
            isShowed = true;
        }

        private void Hide()
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0;
            isShowed = false;
        }
    }
}
