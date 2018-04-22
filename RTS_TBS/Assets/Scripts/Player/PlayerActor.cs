using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD41
{
    [RequireComponent(typeof(PlayerController))]
    public class PlayerActor : TurnActor
    {
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
            turnCost = GetComponent<Status>();
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
                turnCost.Remove(3.0f * Time.deltaTime);
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
