using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD41
{
    public class TurnController : MonoBehaviour
    {
        [SerializeField]
        TurnActor[] actors;


        public delegate void Func();
        public static event Func OnTurnEnded;


        uint currentActorIndex;


        void Awake()
        {
            //Hook with game start/over...
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
            //Test
            actors[0].MakeTurn(true);
        }

        void _OnTurnCostEmpty()
        {
            EndCurrentTurn();
        }

        void _FireEvent_OnTurnEnded()
        {
            if (OnTurnEnded != null) {
                OnTurnEnded();
            }
        }
        //
        //move to next actor..(cycle..)
        void _CycleTurn()
        {

        }

        public void EndCurrentTurn()
        {
            //Todo..
            _FireEvent_OnTurnEnded();
            _CycleTurn();
        }
    }
}
