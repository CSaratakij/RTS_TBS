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
    }
}
