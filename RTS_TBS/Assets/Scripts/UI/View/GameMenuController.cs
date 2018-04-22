using UnityEngine;
using UnityEngine.UI;

namespace LD41
{
    public class GameMenuController : MonoBehaviour
    {
        [SerializeField]
        RectTransform[] views;


        public GameMenuController()
        {
            views = new RectTransform[4];
        }

        public enum View
        {
            MainMenu,
            Tutorial,
            IngameMenu,
            GameOverMenu
        }


        RectTransform currentView;


        void Awake()
        {
            _Initialize();
            _Subscribe_Events();
        }

        void Start()
        {
            _HideAllMenu();
            ShowMenu(View.MainMenu);
        }

        void OnDestroy()
        {
            _Unsubscribe_Events();
        }

        void _Initialize()
        {
            currentView = views[0];
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
            ShowMenu(View.IngameMenu);
        }

        void _OnGameOver()
        {
            ShowMenu(View.GameOverMenu);
        }

        void _HideAllMenu()
        {
            foreach (RectTransform view in views) {
                view.gameObject.SetActive(false);
            }
        }

        public void ShowMenu(View view)
        {
            currentView.gameObject.SetActive(false);
            currentView = views[(int)view];
            currentView.gameObject.SetActive(true);
        }

        public void ShowMenu(string name)
        {
            switch (name)
            {
                case "MainMenu":
                    ShowMenu(View.MainMenu);
                    break;

                case "Tutorial":
                    ShowMenu(View.Tutorial);
                    break;

                default:
                    var errorLog = string.Format("Want to show menu name : {0}, But can't", name);
                    Debug.Log(errorLog);
                    break;
            }
        }
    }
}
