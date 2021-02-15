using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityBase
{
    public class MenuController : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("WANT TO ESCAPE?");
            }
        }

        public void LoadScene(int buildInx)
        {
            SceneManager.LoadScene(buildInx);
        }

        void ExitGame() 
        {
            Application.Quit(0);
        }
    }
}
