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
        CursorLockMode sceneCursorLockMode;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            Return();

            sceneCursorLockMode = Cursor.lockState;
            isVisibleCursor = Cursor.visible;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {

                Time.timeScale = 0;
                ShowMenu();

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;               
            }
        }

        public void Return() 
        {
            Time.timeScale = 1;
            HideMenu();
        }

        public void GoBackToMenu() 
        {
            if (SceneManager.GetActiveScene().buildIndex != startMenuIndx)
            {
                SceneManager.LoadScene(startMenuIndx);
                Debug.Log("Back to menu");
            }
            else
            {
                Application.Quit(1);
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