using System.Collections;
using UnityEngine;

namespace LD41
{
    public class BossActor : TurnActor
    {
        public const int ABILITY_SLASH_COST = 2;
        public const int ABILITY_SHOOT_COST = 12;
        public const int ABILITY_HEAL_COST = 4;
        public const int ABILITY_MOVE_LEFT_COST = 1;
        public const int ABILITY_MOVE_CENTER_COST = 1;
        public const int ABILITY_MOVE_RIGHT_COST = 1;


        [SerializeField]
        Status health;


        SpriteRenderer spriteRenderer;


        public BossActor()
        {
            turnStyle = TurnStyle.Turnbase;
        }

        protected override void Awake()
        {
            base.Awake();
            _Initialize();
            _Subscribe_Events();
        }

        protected override void Update()
        {
            base.Update();
            if (health.IsEmpty) {
                GameController.GameOver();
            }
        }

        protected override void OnDestroy()
        {
            _Unsubscribe_Events();
        }

        void _Initialize()
        {
            Name = "Boss";
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void _Subscribe_Events()
        {
            TurnController.OnTurnStarted += _OnTurnStarted;
        }
        
        void _Unsubscribe_Events()
        {
            TurnController.OnTurnStarted -= _OnTurnStarted;
        }

        void _OnTurnStarted()
        {
            if (isTurn) {
                turnCost.FullRestore();
            }
        }

        IEnumerator _GetHit_Callback()
        {
            yield return new WaitForSeconds(0.5f);
            spriteRenderer.color = Color.white;
        }

        public void RemoveTurnCost(int value)
        {
            turnCost.Remove(value);
        }

        public void RemoveHealth(int value)
        {
            health.Remove(value);
            spriteRenderer.color = Color.red;
            StartCoroutine(_GetHit_Callback());
        }

        public void Move(Transform target)
        {
            transform.position = target.position;
        }

        public void Heal(int value)
        {
            health.Restore(value);
        }

        public void AttackNear()
        {
            //play attack animation..
            //and check if player is near..
            //remove its health every hit..
            //
            //if player is not found -> display miss??
        }

        public void AttackFar()
        {
            //lauch someting toward player??
        }
    }
}
