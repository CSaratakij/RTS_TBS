using UnityEngine;

namespace LD41
{
    [RequireComponent(typeof(Status))]
    public abstract class TurnActor : MonoBehaviour
    {
        [SerializeField]
        protected bool isTurn;

        [SerializeField]
        protected TurnStyle turnStyle;

        [SerializeField]
        protected Status turnCost;


        public Status TurnCost { get { return turnCost; } }


        public delegate void Func();
        public event Func OnTurnCostEmpty;


        protected virtual void Awake()
        {
        }

        protected virtual void OnDestroy()
        {
        }

        protected virtual void Update()
        {
            if (isTurn) {
                TurnCost_Handler();
            }
        }

        protected virtual void TurnCost_Handler()
        {
            switch (turnStyle) {
                case TurnStyle.Realtime:
                    turnCost.Remove(1 * Time.deltaTime);
                    break;

                default:
                    break;
            }

            if (turnCost.IsEmpty) {
                MakeTurn(false);
                _FireEvent_OnTurnCostEmpty();
            }
        }

        void _FireEvent_OnTurnCostEmpty()
        {
            if (OnTurnCostEmpty != null) {
                OnTurnCostEmpty();
            }
        }

        public void MakeTurn(bool value)
        {
            isTurn = value;
        }
    }
}
