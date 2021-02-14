using UnityEngine;

namespace UnityBase.AngryBirds
{
    [RequireComponent(typeof(LineRenderer))]
    public class TrajectoryRenderer : MonoBehaviour
    {
        [SerializeField] int pontsInt;
        private LineRenderer lineRendererComp;

        void Start()
        {
            lineRendererComp = GetComponent<LineRenderer>();
            HideTrajectory();
        }

        public void ShowTrajectory(Vector3 origin, Vector3 speed)
        {
            lineRendererComp.enabled = true;

            Vector3[] points = new Vector3[100];
            lineRendererComp.positionCount = points.Length;

            for (int i = 0; i < points.Length; i++)
            {
                float _time = i * 0.1f;
                points[i] = origin + speed * _time + Physics.gravity * _time * _time / 2f;

                if (points[i].y < -2 || points[i].y > 4)
                {
                    lineRendererComp.positionCount = i;
                    break;
                }
            }

            lineRendererComp.SetPositions(points);
        }

        public void HideTrajectory()
        {
            lineRendererComp.enabled = false;
        }
    }
}
