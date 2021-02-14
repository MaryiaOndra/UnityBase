using UnityEngine;

namespace UnityBase.MemorySimulator
{
    [RequireComponent(typeof (MeshRenderer))]
    public class UsedFigure : MonoBehaviour
    {
        private float speedFlt = 2f;
        private MeshRenderer meshRenderer;
        private int[] rotationAngles = { 0, 30, 60, 70, 150, 168 };

        public int AngleInt { get; private set; }
        public int ColorInt { get; private set; }

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        private void Update()
        {
            if (gameObject.activeSelf)
            {
                MoveToTheMiddle();
            }
        }

        private void MoveToTheMiddle()
        {
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, Time.deltaTime * speedFlt);
        }

        public void SetRandomColor()
        {
            int colorInt = Random.Range((int)FigureColors.White, (int)FigureColors.Red);
            ColorInt = colorInt;

            switch (colorInt)
            {
                case (int)FigureColors.Cyan:
                    meshRenderer.material.color = Color.cyan;
                    break;
                case (int)FigureColors.Green:
                    meshRenderer.material.color = Color.green;
                    break;
                case (int)FigureColors.Red:
                    meshRenderer.material.color = Color.red;
                    break;
                case (int)FigureColors.White:
                    meshRenderer.material.color = Color.white;
                    break;
                case (int)FigureColors.Blue:
                    meshRenderer.material.color = Color.blue;
                    break;
                case (int)FigureColors.Yellow:
                    meshRenderer.material.color = Color.yellow;
                    break;
            }
        }

        public void SetRandomRotation()
        {

            int randomAngle = Random.Range(0, rotationAngles.Length);
            transform.Rotate(Vector3.forward, rotationAngles[randomAngle]);
            AngleInt = randomAngle;
        }
    }

    enum FigureColors
    {
        White,
        Cyan,
        Blue,
        Green,
        Yellow,
        Red
    }
}