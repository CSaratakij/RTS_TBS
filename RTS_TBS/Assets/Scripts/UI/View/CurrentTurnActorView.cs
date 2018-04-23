using UnityEngine;
using UnityEngine.UI;

namespace LD41
{
    public class CurrentTurnActorView : MonoBehaviour
    {
        const string CURRENT_TURN_ACTOR_FORMAT = "Turn : [ {0} ]";


        [SerializeField]
        Text txtCurrentActor;

        [SerializeField]
        TurnController turnController;


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
            txtCurrentActor.text = string.Format(CURRENT_TURN_ACTOR_FORMAT, turnController.CurrentActor.Name); 
        }
    }
}
