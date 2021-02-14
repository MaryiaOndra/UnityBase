using UnityEngine;

namespace UnityBase.PyramidShooter
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] levelPoints;
        [SerializeField] private GameObject[] levelsPrefabs;
        [SerializeField] private GameObject platform;

        GameObject activePlatform;
        GameObject activeLvl;

        int randomLvlInt;
        int randomPointInt;
        float destroyDelay = 0.5f;

        public bool IsAllCubesDropped { get; set; }

        void Start()
        {
            Randomize();
            GenerateNewLevel();
        }

        void Update()
        {
            if (IsAllCubesDropped)
            {
                IsAllCubesDropped = false;

                Randomize();
                DestroyLevel();
                GenerateNewLevel();
            }
        }

        void GenerateNewLevel()
        {
            Transform pointTransform = levelPoints[randomPointInt].transform;

            activeLvl = GameObject.Instantiate(levelsPrefabs[randomLvlInt], pointTransform);
            activePlatform = GameObject.Instantiate(platform, pointTransform);
        }

        void Randomize()
        {
            randomLvlInt = Random.Range(0, levelsPrefabs.Length);
            randomPointInt = Random.Range(0, levelPoints.Length);
        }

        void DestroyLevel()
        {
            GameObject.Destroy(activePlatform, destroyDelay);
            GameObject.Destroy(activeLvl);
        }
    }
}
