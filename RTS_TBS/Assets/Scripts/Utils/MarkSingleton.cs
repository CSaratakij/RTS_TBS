using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD41
{
    public class MarkSingleton : MonoBehaviour
    {
        public static GameObject instance = null;

        void Awake()
        {
            if (instance == null) {
                instance = gameObject;
                DontDestroyOnLoad(gameObject);
            }
            else {
                Destroy(gameObject);
            }
        }
    }
}
