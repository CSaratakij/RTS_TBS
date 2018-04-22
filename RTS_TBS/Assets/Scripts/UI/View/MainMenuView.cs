using UnityEngine;
using UnityEngine.UI;

namespace LD41
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField]
        RectTransform[] views;


        public MainMenuView()
        {
            views = new RectTransform[3];
        }

        enum View
        {
            MainMenu,
            IngameMenu,
            GameOverMenu
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
            GameController.OnGameStart += _OnGameStart;
            GameController.OnGameOver += _OnGameOver;
        }

        void _Unsubscribe_Events()
        {
            GameController.OnGameStart -= _OnGameStart;
            GameController.OnGameOver -= _OnGameOver;
        }

        void _OnGameStart()
        {
            //Test..
            views[(int)View.MainMenu].gameObject.SetActive(false);
        }

        void _OnGameOver()
        {
        }
    }
}
