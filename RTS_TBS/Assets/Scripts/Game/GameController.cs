namespace LD41
{
    public class GameController
    {
        public delegate void Func();
        public static event Func OnGameStart;
        public static event Func OnGameOver;


        static bool isGameStart;
        static bool isGameOver = false;


        static void _FireEvent_OnGameStart()
        {
            if (OnGameStart != null) {
                OnGameStart();
            }
        }

        static void _FireEvent_OnGameOver()
        {
            if (OnGameOver != null) {
                OnGameOver();
            }
        }

        public static void GameStart()
        {
            if (isGameStart) { return; }

            isGameStart = true;
            isGameOver = false;

            _FireEvent_OnGameStart();
        }

        public static void GameOver()
        {
            if (!isGameStart) { return; }
            if (isGameOver) { return; }

            isGameStart = false;
            isGameOver = true;

            _FireEvent_OnGameOver();
        }
    }
}

