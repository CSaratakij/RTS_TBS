using UnityEngine;
using UnityEngine.UI;

namespace LD41
{
    public class GameWinnerView : MonoBehaviour
    {
        const string WINNER_TEXT_FORMAT = "' {0} '";

        [SerializeField]
        Text txtWinner;


        void Awake()
        {
            _Subscribe_Events();
        }

        void OnDestroy()
        {
            _Unsubscribe_Events();
        }

        void OnEnable()
        {
            _UpdateWinner_View();
        }

        void _Subscribe_Events()
        {
            GameController.OnGameOver += _OnGameOver;
        }

        void _Unsubscribe_Events()
        {
            GameController.OnGameOver -= _OnGameOver;
        }

        void _OnGameOver()
        {
            _UpdateWinner_View();
        }

        void _UpdateWinner_View()
        {
            if (!Global.info.winner) { return; }
            txtWinner.text = string.Format(WINNER_TEXT_FORMAT, Global.info.winner.Name);
        }
    }
}
