using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD41
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        float moveForce;

        [SerializeField]
        float dashForce;


        bool isWalk;
        bool isDash;

        Vector2 inputVector;
        Animator anim;
        Rigidbody2D rigid;


        void Awake()
        {
            _Initialize();
        }

        void Update()
        {
            _Input_Handler();
            _Animation_Handler();
        }

        void FixedUpdate()
        {
            if (isDash) {
                rigid.AddForce(inputVector * dashForce, ForceMode2D.Impulse);
                isDash = false;
            }
            else {
                rigid.velocity = inputVector * moveForce;
            }
        }

        void OnDisable()
        {
            _Reset();
        }

        void _Initialize()
        {
            inputVector = Vector2.zero;
            anim = GetComponent<Animator>();
            rigid = GetComponent<Rigidbody2D>();
        }

        void _Input_Handler()
        {
            inputVector.x = Input.GetAxisRaw("Horizontal");
            inputVector.y = Input.GetAxisRaw("Vertical");

            if (inputVector.magnitude > 1.0f) {
                inputVector = inputVector.normalized;
            }

            isWalk = (inputVector.magnitude > 0.0f);

            if (Input.GetButtonDown("Attack")) {
                anim.Play("Attack");
            }

            if (Input.GetButtonDown("Dash")) {
                isDash = true;
            }
        }

        void _Animation_Handler()
        {
            anim.SetBool("isWalk", isWalk);
        }

        void _Reset()
        {
            inputVector = Vector2.zero;
            rigid.velocity = Vector2.zero;

            isWalk = false;
            anim.SetBool("isWalk", false);
        }
    }
}
