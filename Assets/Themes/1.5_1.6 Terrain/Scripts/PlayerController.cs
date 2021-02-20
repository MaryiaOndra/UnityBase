using UnityEngine;

namespace UnityBase.Terrain
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Transform spherePoint;
        [SerializeField] GameObject spherePrefab;
        [SerializeField] Transform verticalTr;
        [SerializeField] float walkSpeed;
        [SerializeField] float runSpeed;
        [SerializeField] float jumpForce;
        [SerializeField] float shootForce;
        [SerializeField] float rechargeTime;

        CharacterController chController;
        Vector3 speedVector;
        LauncherBhv launcher;

        float verticalSpeed;
        float shootTimer;
        float moveSpeed;

        public bool IsGrounded { get; private set; }
        public bool IsMoving { get; private set; }
        public bool IsRunning { get; private set; }
        bool IsRecharge => shootTimer > 0;

        void Awake()
        {
            chController = GetComponent<CharacterController>();

            launcher = GetComponentInChildren<LauncherBhv>();
        }

        void Update()
        {
            ControlMouse();
            Move();
            Jump();
            Shoot();

            chController.Move(speedVector);
        }

        void ControlMouse()
        {
            float _mouseX = Input.GetAxis("Mouse X");
            float _mouseY = Input.GetAxis("Mouse Y") * -1;

            chController.transform.Rotate(Vector3.up, _mouseX);
            verticalTr.Rotate(Vector3.right, _mouseY, Space.Self);
        }

        void Move()
        {
            if (chController.velocity.x != 0 && chController.isGrounded)
                IsMoving = true;
            else
                IsMoving = false;


            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveSpeed = runSpeed;
                IsRunning = true;
            }
            else
            {
                moveSpeed = walkSpeed;
                IsRunning = false;
            }

            float _vertical = Input.GetAxis("Vertical");
            float _horisontal = Input.GetAxis("Horizontal");

            speedVector = transform.forward * _vertical * moveSpeed * Time.deltaTime + transform.right * _horisontal * moveSpeed * Time.deltaTime;
        }

        void Jump()
        {
            verticalSpeed = chController.velocity.y;
            float _jumpAxis = Input.GetAxis("Jump");

            if (chController.isGrounded && verticalSpeed < 0)
            {
                verticalSpeed = Physics.gravity.y;
            }

            if (chController.isGrounded && _jumpAxis > 0)
            {
                verticalSpeed = jumpForce;
            }

            verticalSpeed += Physics.gravity.y * Time.deltaTime;
            speedVector += transform.up * verticalSpeed * Time.deltaTime;
        }

        void Shoot()
        {
            float _fireAxis = Input.GetAxis("Fire1");

            if (shootTimer > 0)
            {
                shootTimer -= Time.deltaTime;
                if (shootTimer < 0)
                    shootTimer = 0;
            }

            if (_fireAxis > 0 && !IsRecharge)
            {
                Rigidbody _sphereRgBd = Instantiate(spherePrefab).GetComponent<Rigidbody>();
                _sphereRgBd.transform.position = spherePoint.position;
                _sphereRgBd.transform.rotation = spherePoint.rotation;

                _sphereRgBd.AddForce(_sphereRgBd.transform.forward * shootForce, ForceMode.Impulse);

                launcher.LauncherAudioSourse.Play();

                shootTimer = rechargeTime;
            }
        }
    }
}

