using DG.Tweening;
using System;
using UnityEngine;

namespace UnityBase.SolarSystem
{
    public class Planet : MonoBehaviour
    {
        [SerializeField] private float _selfRotationSpeed;
        [SerializeField] private float _planetSpaceSpeed;
        [SerializeField] private GameObject _rotationCenter;
        [SerializeField] private int segments = 2000;

        private float _scaleFactor = 2;

        [SerializeField] float _minEllipseRadius;
        [SerializeField] float _maxEllipseRadius;


        LineRenderer lineRenderer;
        Vector3[] pathArray;


        private void Awake()
        {
            transform.localScale = transform.localScale * _scaleFactor;
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.positionCount = segments + 1;
            pathArray = new Vector3[segments + 1];
        }

        private void Start()
        {
            transform.position = pathArray[segments];
            DrowTrajectory();
            transform.DOPath(pathArray, _planetSpaceSpeed * segments).SetLoops(-1);
        }

        private void DrowTrajectory()
        {
            float angle = 20;

            for (int i = 0; i < (segments + 1); i++)
            {
                float xPos = Mathf.Cos(angle) * _minEllipseRadius;
                float yPos = Mathf.Sin(angle) * _maxEllipseRadius;

                Vector3 _position = new Vector3(xPos, 0, yPos);
                lineRenderer.SetPosition(i, _position );
                pathArray[i] = _position;
                angle += (360f / segments);
            }
        }

        private void Update()
        {
            RotateAroundYourself();
            //RotateLikeEllipse();
        }

        private void RotateAroundYourself()
        {
            transform.Rotate(Vector3.up, _selfRotationSpeed * Time.deltaTime);
        }


        //private void RotateLikeEllipse()
        //{
        //    angle += _planetSpaceSpeed * Time.deltaTime;

        //    float xPos = Mathf.Cos(angle) * _minEllipseRadius;
        //    float yPos = Mathf.Sin(angle) * _maxEllipseRadius;

        //    transform.position = new Vector3(xPos, 0, yPos);
        //}
    }
}
