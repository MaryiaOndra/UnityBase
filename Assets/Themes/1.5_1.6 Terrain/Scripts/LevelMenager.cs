using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityBase.Terrain
{
    public class LevelMenager : MonoBehaviour
    {
        DroppedObjectsDetector[] levelsWithObjects;
        bool IsAllLevelsDone;
        int countLevels;

        void Awake()
        {
            Cursor.visible = false;
            levelsWithObjects = GetComponentsInChildren<DroppedObjectsDetector>();
        }

        void Update()
        {
            if (!IsAllLevelsDone)
            {
                foreach (var level in levelsWithObjects)
                {
                    if (!level.IsAllObjectsDropped)
                    {
                        countLevels = 0;
                    }
                    else
                    {
                        countLevels++;

                        if (countLevels == levelsWithObjects.Length)
                        {
                            IsAllLevelsDone = true;
                        }
                    }
                }
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }
}
