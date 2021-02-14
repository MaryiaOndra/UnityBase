using UnityEngine;
using UnityEngine.Animations;

namespace UnityBase.TileLevel
{
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
}
