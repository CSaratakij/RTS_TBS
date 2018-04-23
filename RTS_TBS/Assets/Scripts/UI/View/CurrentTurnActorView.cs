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

        [SerializeField]
        RectTransform[] turnImages = new RectTransform[2];


        enum TurnImage
        {
            Player,
            Boss
        }

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
            _Update_Text();
            _Update_Image();
        }

        void _Update_Text()
        {
            string actorName = turnController.CurrentActor.Name;
            txtCurrentActor.text = string.Format(CURRENT_TURN_ACTOR_FORMAT, actorName); 
        }

        void _Update_Image()
        {
            string actorName = turnController.CurrentActor.Name;
            turnImages[(int)TurnImage.Player].gameObject.SetActive(actorName.Equals("Phillip"));
            turnImages[(int)TurnImage.Boss].gameObject.SetActive(actorName.Equals("Josh"));
        }
    }
}
