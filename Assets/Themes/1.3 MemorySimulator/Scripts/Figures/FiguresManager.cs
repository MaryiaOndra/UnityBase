using UnityEngine;

namespace UnityBase.MemorySimulator
{
    public class FiguresManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] usedPrefabs;

        private UsedFigure[] workPrefabs;
        private bool[] comparedAnswers;
        private Vector3 startPositionV3 = new Vector3(4, 0);

        private int randomPrefabNmb;
        private int savedPrefabNmbrInt;
        private int savedPrefabAngleInt;
        private int savedPrefabColorInt;
        private int figureCounterInt;

        public int AnswerCounterInt { get; private set; }
        public UsedFigure WorkPrefab => workPrefabs[randomPrefabNmb];

        private void Start()
        {
            for (int i = 0; i < usedPrefabs.Length; i++)
            {
                GameObject.Instantiate(usedPrefabs[i], transform).SetActive(false);
            }

            workPrefabs = GetComponentsInChildren<UsedFigure>(true);

            ActivateNewPrefab();
        }

        private void ActivateNewPrefab()
        {
            figureCounterInt++;

            randomPrefabNmb = Random.Range(0, usedPrefabs.Length);
            UsedFigure activePrefabGO = workPrefabs[randomPrefabNmb];

            activePrefabGO.SetRandomColor();
            activePrefabGO.SetRandomRotation();
            activePrefabGO.gameObject.SetActive(true);
        }

        public void ActivateNextFigure()
        {
            DeactivatePrevPrefab();

            if (figureCounterInt > 1)
            {
                CompareFigures();
                CalculateResult();
            }

            SavePrevFigureParams();
            ActivateNewPrefab();
        }

        private void DeactivatePrevPrefab()
        {
            workPrefabs[randomPrefabNmb].transform.position = startPositionV3;
            workPrefabs[randomPrefabNmb].gameObject.SetActive(false);
        }


        private void SavePrevFigureParams()
        {
            savedPrefabNmbrInt = randomPrefabNmb;
            savedPrefabAngleInt = workPrefabs[randomPrefabNmb].AngleInt;
            savedPrefabColorInt = workPrefabs[randomPrefabNmb].ColorInt;
        }

        private void CompareFigures()
        {
            bool isSameNbr = randomPrefabNmb.Equals(savedPrefabNmbrInt);
            bool isSameColor = workPrefabs[randomPrefabNmb].ColorInt.Equals(savedPrefabColorInt);
            bool isSameAngle = workPrefabs[randomPrefabNmb].AngleInt.Equals(savedPrefabAngleInt);
            comparedAnswers = new bool[] { isSameNbr, isSameColor, isSameAngle };
        }

        private void CalculateResult()
        {
            AnswerCounterInt = 0;

            foreach (var answer in comparedAnswers)
            {
                if (answer == true)
                    AnswerCounterInt++;
            }

            Debug.Log("CALCULATED ANSWER: " + AnswerCounterInt);
        }
    }
}
