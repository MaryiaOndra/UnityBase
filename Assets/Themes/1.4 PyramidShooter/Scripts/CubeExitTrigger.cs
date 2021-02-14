using UnityEngine;

namespace UnityBase.PyramidShooter
{
    public class CubeExitTrigger : MonoBehaviour
    {
        public bool IsCubeExitTrigger { get; private set; }
        LevelPyramid levelPyramid;
        int touchCountInt;


        void Start()
        {
            levelPyramid = GetComponentInParent<LevelPyramid>();
        }

        void OnTriggerEnter(Collider other)
        {
            if (touchCountInt < 1)
            {
                IsCubeExitTrigger = true;
                touchCountInt++;
                levelPyramid.CountCubesInt++;
                levelPyramid.CheckDroppedCubes();
            }
        }
    }
}
