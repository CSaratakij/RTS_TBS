using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD41
{
    public class InGamePanelView : MonoBehaviour
    {
        [SerializeField]
        TurnActor actor;


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
            TurnController.OnTurnStarted += _OnTurnStarted;
        }

        void _Unsubscribe_Events()
        {
            TurnController.OnTurnStarted -= _OnTurnStarted;
        }

        void _OnTurnStarted()
        {
            gameObject.SetActive(actor.IsTurn);
        }
    }
}
