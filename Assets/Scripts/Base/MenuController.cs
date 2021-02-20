using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityBase
{
    public class MenuController : MonoBehaviour
    {
        private void Awake()
        {
            Cursor.visible = true;
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
