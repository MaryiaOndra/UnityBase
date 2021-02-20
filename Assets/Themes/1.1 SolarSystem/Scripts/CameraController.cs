using UnityEngine;

namespace UnityBase.SolarSystem
{
    public class CameraController : MonoBehaviour
    {
        private float speed = 50;

        private void Awake()
        {
            Cursor.visible = false;
        }

        private void Update()
        {
            float _horizontal = Input.GetAxis("Horizontal");
            float _vertical = Input.GetAxis("Vertical");

            transform.position += new Vector3(_horizontal, 0, _vertical) * speed * Time.deltaTime;
        }
    }
}
