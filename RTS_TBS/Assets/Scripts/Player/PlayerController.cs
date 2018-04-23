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

        [SerializeField]
        Transform hitOrigin;

        [SerializeField]
        Vector2 size;

        [SerializeField]
        LayerMask actorMask;


        int hitCount;

        bool isWalk;
        bool isDash;
        bool isBossInAttackRange;

        Vector2 inputVector;
        Animator anim;

        Collider2D[] hits;
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
            hitCount = Physics2D.OverlapBoxNonAlloc(hitOrigin.position, size, 0.0f, hits, actorMask);
            isBossInAttackRange = (hitCount > 0 && hits[0].CompareTag("Boss"));

            _Movement_Handler();
        }

        void OnDisable()
        {
            _Reset();
        }

        void _Initialize()
        {
            hits = new Collider2D[1];
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

                if (isBossInAttackRange) {
                    var boss = hits[0].gameObject.GetComponent<BossActor>();

                    if (boss) {
                        //Need to change to attack point..
                        boss.RemoveHealth(15);
                    }
                }
            }

            if (Input.GetButtonDown("Dash")) {
                isDash = true;
            }
        }

        void _Animation_Handler()
        {
            anim.SetBool("isWalk", isWalk);
        }

        void _Movement_Handler()
        {
            if (isDash) {
                rigid.AddForce(inputVector * dashForce, ForceMode2D.Impulse);
                isDash = false;
            }
            else {
                rigid.velocity = inputVector * moveForce;
            }
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
