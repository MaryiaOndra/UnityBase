using UnityEngine;

namespace UnityBase.SolarSystem
{
    public class Planet : MonoBehaviour
    {
        [SerializeField] private float _selfRotationSpeed;
        [SerializeField] private float _planetSpaceSpeed;
        [SerializeField] private GameObject _rotationCenter;

        private float _scaleFactor = 2;

        [SerializeField] float _minEllipseRadius;
        [SerializeField] float _maxEllipseRadius;
        private float _angle;

        private void Awake()
        {
            transform.localScale = transform.localScale * _scaleFactor;
        }

        private void Update()
        {
            RotateAroundYourself();
            RotateLikeEllipse();
        }

        private void RotateAroundYourself()
        {
            transform.Rotate(Vector3.up, _selfRotationSpeed * Time.deltaTime);
        }


        private void RotateLikeEllipse()
        {
            _angle += _planetSpaceSpeed * Time.deltaTime;

            float xPos = Mathf.Cos(_angle) * _minEllipseRadius;
            float yPos = Mathf.Sin(_angle) * _maxEllipseRadius;

            transform.position = new Vector3(xPos, 0, yPos);
        }
    }
}
