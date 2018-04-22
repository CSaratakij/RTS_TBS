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


        bool isWalk;
        bool isAttack;

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
            rigid.velocity = (inputVector * moveForce);
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
            isAttack = Input.GetButtonDown("Attack");
        }

        void _Animation_Handler()
        {
            anim.SetBool("isWalk", isWalk);
            anim.SetBool("isAttack", isAttack);
        }

        void _Reset()
        {
            inputVector = Vector2.zero;
            rigid.velocity = Vector2.zero;

            isWalk = false;
            isAttack = false;

            anim.SetBool("isWalk", false);
            anim.SetBool("isAttack", false);
        }
    }
}
