using System.Collections;
using UnityEngine;

namespace LD41
{
    [RequireComponent(typeof(PlayerController))]
    public class PlayerActor : TurnActor
    {
        const float WALK_TURN_COST = 3.0f;
        const float ATTACK_TURN_COST = 5.0f;
        const float DASH_TURN_COST = 8.0f;


        [SerializeField]
        Status health;


        SpriteRenderer spriteRenderer;


        public PlayerActor()
        {
            turnStyle = TurnStyle.Realtime;
        }


        PlayerController playerController;


        protected override void Awake()
        {
            base.Awake();
            _Initialize();
            _Subscribe_Events();
        }

        protected override void Update()
        {
            base.Update();
            _Component_Handler();

            if (health.IsEmpty) {
                GameController.GameOver();
            }
        }

        protected override void TurnCost_Handler()
        {
            base.TurnCost_Handler();

            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");

            if ((inputX != 0.0f) || (inputY != 0.0f)) {
                turnCost.Remove(WALK_TURN_COST * Time.deltaTime);
            }

            if (Input.GetButtonDown("Attack")) {
                turnCost.Remove(ATTACK_TURN_COST);
            }

            if (Input.GetButtonDown("Dash")) {
                turnCost.Remove(DASH_TURN_COST);
            }
        }

        protected override void OnDestroy()
        {
            _Unsubscribe_Events();
        }

        void _Initialize()
        {
            Name = "Phillip";
            spriteRenderer = GetComponent<SpriteRenderer>();
            playerController = GetComponent<PlayerController>();
        }

        void _Subscribe_Events()
        {
            GameController.OnGameOver += _OnGameOver;
            TurnController.OnTurnStarted += _OnTurnStarted;
        }

        void _Unsubscribe_Events()
        {
            GameController.OnGameOver -= _OnGameOver;
            TurnController.OnTurnStarted -= _OnTurnStarted;
        }

        void _OnGameOver()
        {
            if (!health.IsEmpty) {
                Global.info.winner = this;
            }
        }

        void _OnTurnStarted()
        {
            if (isTurn) {
                turnCost.FullRestore();
            }
        }

        void _Component_Handler()
        {
            if (playerController.enabled != isTurn) {
                playerController.enabled = isTurn;
            }
        }

        IEnumerator _GetHit_Callback()
        {
            yield return new WaitForSeconds(0.5f);
            spriteRenderer.color = Color.white;
        }

        public void RemoveHealth(int value)
        {
            health.Remove(value);
            spriteRenderer.color = Color.red;
            StartCoroutine(_GetHit_Callback());
        }
    }
}
