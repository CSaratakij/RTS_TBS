using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD41
{
    public class TurnController : MonoBehaviour
    {
        [SerializeField]
        TurnActor[] actors;


        public TurnActor CurrentActor { get { return actors[currentActorIndex]; } }
        public delegate void Func();
        public static event Func OnTurnStarted;
        public static event Func OnTurnEnded;


        uint currentActorIndex = 0;


        void Awake()
        {
            _Subscribe_Events();
        }

        void OnDestroy()
        {
            _Unsubscribe_Events();
        }

        void _Subscribe_Events()
        {
            //GameController hook here..
            GameController.OnGameStart += _OnGameStart;

            foreach (TurnActor actor in actors) {
                actor.OnTurnCostEmpty += _OnTurnCostEmpty;
            }
        }

        void _Unsubscribe_Events()
        {
            //GameController hook here..
            GameController.OnGameStart -= _OnGameStart;

            foreach (TurnActor actor in actors) {
                actor.OnTurnCostEmpty -= _OnTurnCostEmpty;
            }
        }

        void _OnGameStart()
        {
            actors[currentActorIndex].MakeTurn(true);
            _FireEvent_OnTurnStarted();
        }

        void _OnTurnCostEmpty()
        {
            EndCurrentTurn();
        }

        void _FireEvent_OnTurnStarted()
        {
            if (OnTurnStarted != null) {
                OnTurnStarted();
            }
        }

        void _FireEvent_OnTurnEnded()
        {
            if (OnTurnEnded != null) {
                OnTurnEnded();
            }
        }

        void _CycleTurn()
        {
            actors[currentActorIndex].MakeTurn(false);
            currentActorIndex = ((currentActorIndex + 1) < actors.Length) ? (currentActorIndex + 1) : 0;
            actors[currentActorIndex].MakeTurn(true);
        }

        public void EndCurrentTurn()
        {
            _FireEvent_OnTurnEnded();
            _CycleTurn();
            _FireEvent_OnTurnStarted();
        }
    }
}
