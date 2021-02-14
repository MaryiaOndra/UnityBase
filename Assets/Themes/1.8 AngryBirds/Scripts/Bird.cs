using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityBase.AngryBirds
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bird : MonoBehaviour
    {
        const float MAX_FORCE = 11;

        Rigidbody2D rBody2D;
        BirdController birdController;
        TrajectoryRenderer trajectory;
        Vector2 startPos;
        float lifeTime = 3f;

        private void Awake()
        {
            rBody2D = GetComponent<Rigidbody2D>();
            rBody2D.bodyType = RigidbodyType2D.Static;
            birdController = FindObjectOfType<BirdController>();
            trajectory = FindObjectOfType<TrajectoryRenderer>();
        }

        public void OnDragBegin(BaseEventData _evData)
        {
            var _pointerEv = _evData as PointerEventData;
            startPos = _pointerEv.position;
        }

        public void OnDrag(BaseEventData _evData)
        {
            var _pointerEv = _evData as PointerEventData;
            var _direction = (startPos - _pointerEv.position).normalized;
            float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            rBody2D.SetRotation(rotation);
            Vector2 _speed = _direction * MAX_FORCE;
            trajectory.ShowTrajectory(transform.position, _speed);
        }

        public void OnDragEnd(BaseEventData _evData)
        {
            trajectory.HideTrajectory();
            birdController.CreateNextBird();

            var _pointerEv = _evData as PointerEventData;
            var _direction = (_pointerEv.position - startPos).normalized * -1;
            rBody2D.bodyType = RigidbodyType2D.Dynamic;
            rBody2D.AddForce(_direction * MAX_FORCE, ForceMode2D.Impulse);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Ball _))
            {
                birdController.CatchBall();
                Destroy(gameObject);
            }
            else if (!collision.gameObject.TryGetComponent(out Bird _))
            {
                Destroy(gameObject, lifeTime);
            }
        }
    }
}
