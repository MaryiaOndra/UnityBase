using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityBase.TileLevel
{
    public enum PlayerState
    {
        Idle,
        Walk,
        Jump,
        Die,
        Fall
    }

    public class PlayerController : MonoBehaviour
    {
        static readonly int INT_STATE = Animator.StringToHash("State");

        [SerializeField] float speed = 0;
        [SerializeField] float jumpForce = 0;

        Rigidbody2D rBody2D;
        PlayerState state;
        Animator playerAnimator;
        List<Collider2D> collider2Ds;
        ContactFilter2D groundFilter2D;
        ContactFilter2D wallsFilterLeft2D;
        ContactFilter2D wallsFilterRight2D;
        SpriteRenderer playerR;
        bool IsAngleJumpPlace;

        void Awake()
        {
            rBody2D = GetComponent<Rigidbody2D>();
            playerAnimator = GetComponent<Animator>();
            playerR = GetComponent<SpriteRenderer>();

            collider2Ds = new List<Collider2D>();
            groundFilter2D = new ContactFilter2D();
            groundFilter2D.SetNormalAngle(89, 91);
            groundFilter2D.useNormalAngle = true;

            wallsFilterLeft2D = new ContactFilter2D();
            wallsFilterLeft2D.SetNormalAngle(-1, 1);
            wallsFilterLeft2D.useNormalAngle = true;
            wallsFilterRight2D = new ContactFilter2D();
            wallsFilterRight2D.SetNormalAngle(179, 180);
            wallsFilterRight2D.useNormalAngle = true;

        }

        private void OnEnable()
        {
            playerAnimator.GetBehaviour<PlayerAnimCallback>().DiedAction = OnDied;
        }

        void FixedUpdate()
        {
            if (State != PlayerState.Die)
            {
                float _horizontalValue = Input.GetAxis("Horizontal");
                float _jumpValue = Input.GetAxis("Jump");

                var _velocity = rBody2D.velocity;

                if (!IsAngleJumpPlace)
                    _velocity.x = Vector2.right.x * speed * _horizontalValue;

                if (_velocity.x > 0)
                {
                    playerR.flipX = false;
                }
                else if (_velocity.x < 0)
                {
                    playerR.flipX = true;
                }

                if (IsGrounded)
                {
                    if (_jumpValue > 0)
                    {
                        _velocity.y = Vector2.up.y * jumpForce;
                        State = PlayerState.Jump;
                    }
                    else if (_velocity.x == 0)
                    {
                        State = PlayerState.Idle;
                    }
                    else
                    {
                        State = PlayerState.Walk;
                    }
                }
                else
                {
                    if (IsAngleJumpPlace)
                    {
                        if (_jumpValue > 0)
                        {
                            if (IsNearLeftWall)
                            {
                                _velocity = Vector2.one * jumpForce;
                                playerR.flipX = false;
                            }
                            else if (IsNearRightWall)
                            {
                                _velocity.x = Vector2.one.x * jumpForce * -1;
                                _velocity.y = Vector2.one.y * jumpForce;
                                playerR.flipX = true;
                            }
                        }
                    }

                    if (_velocity.y < 0)
                    {
                        State = PlayerState.Fall;
                    }
                    else
                    {
                        State = PlayerState.Jump;
                    }
                }

                rBody2D.velocity = _velocity;
            }
        }

        public bool IsGrounded
        {
            get
            {
                bool _value = false;
                int _counts = rBody2D.GetContacts(groundFilter2D, collider2Ds);
                _value = _counts > 0;
                return _value;
            }
        }

        bool IsNearRightWall
        {
            get
            {
                bool _value = false;
                int _counts = rBody2D.GetContacts(wallsFilterRight2D, collider2Ds);
                _value = _counts > 0;
                return _value;
            }
        }

        bool IsNearLeftWall
        {
            get
            {
                bool _value = false;
                int _counts = rBody2D.GetContacts(wallsFilterLeft2D, collider2Ds);
                _value = _counts > 0;
                return _value;
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag == "Poison" || collision.transform.tag == "Enemy")
            {
                State = PlayerState.Die;
            }
        }

        public void OnDied()
        {
            Debug.Log("OnDied");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        PlayerState State
        {
            get => state;
            set
            {
                state = value;
                playerAnimator.SetInteger(INT_STATE, (int)state);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.tag == "Tube")
            {
                IsAngleJumpPlace = true;
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.tag == "HappyEnd")
            {
                if (IsGrounded)
                {
                    rBody2D.AddForce(Vector2.up * jumpForce / 2, ForceMode2D.Impulse);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.transform.tag == "Tube")
            {
                IsAngleJumpPlace = false;
            }
        }
    }
}
