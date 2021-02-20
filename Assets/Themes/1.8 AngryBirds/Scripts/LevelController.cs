
using UnityEngine;

namespace UnityBase.AngryBirds
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] GameObject[] levelPrefabs;

        GameObject level;
        int levelIndx = 0;



        void Start()
        {
            CreateLevel();
        }

        void CreateLevel()
        {
            level = Instantiate(levelPrefabs[levelIndx], gameObject.transform);
            levelIndx++;
            if (levelIndx == 3)
                levelIndx = 0;
        }

        public void CreateNewLevel()
        {
            Destroy(level);
            CreateLevel();
        }
    }
}
