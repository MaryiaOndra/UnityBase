using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CameraController : MonoBehaviour
{
    Camera mainCamera;
    PositionConstraint positionConstraint;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
        positionConstraint = GetComponent<PositionConstraint>();
    }


}
