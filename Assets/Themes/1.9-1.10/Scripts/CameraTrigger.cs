using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] PositionConstraint positionConstraint;

    private void OnTriggerStay2D(Collider2D collision)
    {
        positionConstraint.translationAxis = Axis.Y | Axis.X;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        positionConstraint.translationAxis = Axis.X;
        positionConstraint.locked = true;
    }
}
