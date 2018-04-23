using UnityEngine;
using UnityEngine.UI;

namespace LD41
{
    public class AbilitySelectorView : MonoBehaviour
    {
        [SerializeField]
        BossActor boss;

        [SerializeField]
        Button[] buttons;


        public AbilitySelectorView()
        {
            buttons = new Button[6];
        }

        enum ButtonAbility
        {
            Slash,
            Shoot,
            Heal,
            MoveLeft,
            MoveCenter,
            MoveRight
        }

        void Update()
        {
            _Button_Handler();
        }

        void _Button_Handler()
        {
            var currentTurnCost = (int)boss.TurnCost.Current;

            buttons[(int)ButtonAbility.Slash].gameObject.SetActive(currentTurnCost >= BossActor.ABILITY_SLASH_COST);
            buttons[(int)ButtonAbility.Shoot].gameObject.SetActive(currentTurnCost >= BossActor.ABILITY_SHOOT_COST);
            buttons[(int)ButtonAbility.Heal].gameObject.SetActive(currentTurnCost >= BossActor.ABILITY_HEAL_COST);
            buttons[(int)ButtonAbility.MoveLeft].gameObject.SetActive(currentTurnCost >= BossActor.ABILITY_MOVE_LEFT_COST);
            buttons[(int)ButtonAbility.MoveCenter].gameObject.SetActive(currentTurnCost >= BossActor.ABILITY_MOVE_CENTER_COST);
            buttons[(int)ButtonAbility.MoveRight].gameObject.SetActive(currentTurnCost >= BossActor.ABILITY_MOVE_RIGHT_COST);
        }
    }
}
