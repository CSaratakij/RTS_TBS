using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD41
{
    public class Timer : MonoBehaviour
    {
        [SerializeField]
        float currentTime;

        [SerializeField]
        float maxTime;


        public delegate void Func();
        public event Func OnTimerStopped;

        public int Minute { get { return (int)(currentTime / 60); } }
        public int Seconds { get { return (int)(currentTime - Seconds); } }


        bool isStart;
        bool isPause;


        void Awake()
        {
            isStart = false;
            isPause = false;
        }

        void Update()
        {
            if (!isStart) { return; }
            if (isPause) { return; }

            currentTime -= (1.0f * Time.deltaTime); 

            if (currentTime <= 0.0f && isStart) {
                Reset();
                _FireEvent_OnTimerStopped();
            }
        }

        void _FireEvent_OnTimerStopped()
        {
            if (OnTimerStopped != null) {
                OnTimerStopped();
            }
        }

        void OnDestroy()
        {
            OnTimerStopped = null;
        }

        public void CountDown()
        {
            if (isStart) { return; }
            isStart = true;
        }

        public void Pause(bool value)
        {
            isPause = value;
        }

        public void Reset()
        {
            isStart = false;
            isPause = false;
            currentTime = maxTime;
        }

        public override string ToString()
        {
            string formatMinute = (Minute < 10) ? "0{0}" : "{0}";
            string formatSeconds = (Seconds < 10) ? "0{0}" : "{0}";

            string formatResult = (formatMinute + formatSeconds);
            string result = string.Format(formatResult, Minute, Seconds);

            return result;
        }
    }
}
