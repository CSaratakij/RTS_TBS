using UnityEngine;

namespace LD41
{
    public class BossActor : TurnActor
    {
        [SerializeField]
        Status health;

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

        public void RemoveTurnCost(int value)
        {
            turnCost.Remove(value);
        }

        public void Move(Transform target)
        {
            //Move to that pos with lerp??
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
