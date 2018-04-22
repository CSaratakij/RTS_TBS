using System.Collections;
using System.Collections.Generic;
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


        public PlayerActor()
        {
            turnStyle = TurnStyle.Realtime;
        }


        PlayerController playerController;


        protected override void Awake()
        {
            base.Awake();
            playerController = GetComponent<PlayerController>();
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

        void _Component_Handler()
        {
            if (playerController.enabled != isTurn) {
                playerController.enabled = isTurn;
            }
        }
    }
}
