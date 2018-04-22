using UnityEngine;
using UnityEngine.UI;

namespace LD41
{
    public class PanelInfoView : MonoBehaviour
    {
        const string HEALTH_FORMAT = "Health : {0} / {1}";
        const string STAMINA_FORMAT = "Stamina : {0} / {1}";


        [SerializeField]
        Text txtHealth;

        [SerializeField]
        Status health;

        [SerializeField]
        Text txtStamina;

        [SerializeField]
        Status turnCost;


        void Update()
        {
            _UpdateInfo();
        }

        void _UpdateInfo()
        {
            _UpdateHealth();
            _UpdateStamina();
        }

        void _UpdateHealth()
        {
            txtHealth.text = string.Format(HEALTH_FORMAT, (int)health.Current, (int)health.Maximum);
        }

        void _UpdateStamina()
        {
            txtStamina.text = string.Format(STAMINA_FORMAT, (int)turnCost.Current, (int)turnCost.Maximum);
        }
    }
}
