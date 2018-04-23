using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD41
{
    public class Global : MonoBehaviour
    {
        public static GameInfo info = new GameInfo();
        public static void Clear()
        {
            info.winner = null;
        }
    }
}
