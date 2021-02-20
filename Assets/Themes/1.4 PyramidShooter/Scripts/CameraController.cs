using UnityEngine;

namespace UnityBase.PyramidShooter
{
    public class CameraController : MonoBehaviour
    {
        float sensitivity = 10f;
        float maxYAngle = 80f;
        Vector2 currentRotation;

        void Awake()
        {
           // Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void Update()
        {
            RotateCamera();
        }

        void RotateCamera()
        {
            currentRotation.x += Input.GetAxis("Mouse X") * sensitivity;
            currentRotation.y -= Input.GetAxis("Mouse Y") * sensitivity;
            currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
            currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);
            Camera.main.transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
            //if (Input.GetMouseButtonDown(0))
            //    Cursor.lockState = CursorLockMode.Locked;
            transform.eulerAngles = new Vector3(currentRotation.y, currentRotation.x, 0.0f);
        }
    }
}
