using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityBase
{
    [RequireComponent(typeof(CanvasGroup))]
    public class EscapeMenu : MonoBehaviour
    {
        int startMenuIndx = 0;
        CanvasGroup canvasGroup;

        bool isVisibleCursor;

        private void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            isVisibleCursor = Cursor.visible;
            Time.timeScale = 1;
            HideMenu();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Time.timeScale = 0;
                Cursor.visible = true;
                ShowMenu();
            }
        }

        public void Return() 
        {
            Time.timeScale = 1;
            Cursor.visible = isVisibleCursor;
            HideMenu();
        }

        public void GoBackToMenu() 
        {
            if (SceneManager.GetActiveScene().buildIndex != startMenuIndx)
            {
                SceneManager.LoadScene(startMenuIndx);
            }
            else
            {
                Application.Quit();
                Debug.Log("QUIT APPLICATION");
            }
        }

        void ShowMenu()
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

        void HideMenu()
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }
}