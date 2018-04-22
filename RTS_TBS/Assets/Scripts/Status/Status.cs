using UnityEngine;

namespace LD41
{
    public class Status : MonoBehaviour, IStatus<float>
    {
        [SerializeField]
        float current;

        [SerializeField]
        float maximum;


        public float Current { get { return current; } }
        public bool IsEmpty { get { return current <= 0; } } 


        public void FullRestore()
        {
            current = maximum;
        }

        public void Clear()
        {
            current = 0;
        }

        public void Restore(float value)
        {
            current = (current + value) > maximum ? maximum : (current + value);
        }

        public void Remove(float value)
        {
            current = (current - value) < 0 ? 0 : (current - value);
        }
    }
}
