using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD41
{
    public class BossActor : TurnActor
    {
        [SerializeField]
        Status health;

        public BossActor()
        {
            turnStyle = TurnStyle.Turnbase;
        }

        protected override void Update()
        {
            base.Update();
            if (health.IsEmpty) {
                GameController.GameOver();
            }
        }

        public void RemoveTurnCost(int value)
        {
            turnCost.Remove(value);
        }

        public void Move(Transform target)
        {
            //Move to that pos with lerp??
        }

        public void Heal(int value)
        {
            health.Restore(value);
        }

        public void AttackNear()
        {
            //play attack animation..
            //and check if player is near..
            //remove its health every hit..
            //
            //if player is not found -> display miss??
        }

        public void AttackFar()
        {
            //lauch someting toward player??
        }
    }
}
