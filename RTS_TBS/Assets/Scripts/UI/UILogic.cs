using UnityEngine;
using UnityEngine.SceneManagement;

namespace LD41
{
    public class UILogic : MonoBehaviour
    {
        public void StartGame()
        {
            GameController.GameStart();
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void Restart()
        {
            Global.Clear();
            var currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}
