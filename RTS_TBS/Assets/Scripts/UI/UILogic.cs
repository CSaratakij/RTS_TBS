using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
