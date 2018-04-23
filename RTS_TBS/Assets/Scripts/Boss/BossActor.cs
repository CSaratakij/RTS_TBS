﻿using System.Collections;
using UnityEngine;

namespace LD41
{
    public class BossActor : TurnActor
    {
        public const int ABILITY_SLASH_COST = 2;
        public const int ABILITY_SHOOT_COST = 12;
        public const int ABILITY_HEAL_COST = 4;
        public const int ABILITY_MOVE_LEFT_COST = 1;
        public const int ABILITY_MOVE_CENTER_COST = 1;
        public const int ABILITY_MOVE_RIGHT_COST = 1;


        [SerializeField]
        Status health;

        [SerializeField]
        float dashForce;

        [SerializeField]
        float attackRange;

        [SerializeField]
        Transform hitOrigin;

        [SerializeField]
        Vector2 size;

        [SerializeField]
        LayerMask playerMask;


        int hitCount;
        bool isPlayerInAttackRange;

        Collider2D[] hits;
        Animator anim;
        SpriteRenderer spriteRenderer;


        public BossActor()
        {
            turnStyle = TurnStyle.Turnbase;
        }

        protected override void Awake()
        {
            base.Awake();
            _Initialize();
            _Subscribe_Events();
        }

        protected override void Update()
        {
            base.Update();
            if (health.IsEmpty) {
                GameController.GameOver();
            }
        }

        void FixedUpdate()
        {
            hitCount = Physics2D.OverlapBoxNonAlloc(hitOrigin.position, size, 0.0f, hits, playerMask);
            isPlayerInAttackRange = (hitCount > 0 && hits[0].CompareTag("Player") && Vector2.Distance(hits[0].transform.position, hitOrigin.position) <= attackRange);
        }

        protected override void OnDestroy()
        {
            _Unsubscribe_Events();
        }

        void _Initialize()
        {
            Name = "Boss";
            hits = new Collider2D[1];
            anim = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void _Subscribe_Events()
        {
            TurnController.OnTurnStarted += _OnTurnStarted;
        }
        
        void _Unsubscribe_Events()
        {
            TurnController.OnTurnStarted -= _OnTurnStarted;
        }

        void _OnTurnStarted()
        {
            if (isTurn) {
                turnCost.FullRestore();
            }
        }

        IEnumerator _GetHit_Callback()
        {
            yield return new WaitForSeconds(0.5f);
            spriteRenderer.color = Color.white;
        }

        public void RemoveTurnCost(int value)
        {
            turnCost.Remove(value);
        }

        public void RemoveHealth(int value)
        {
            health.Remove(value);
            spriteRenderer.color = Color.red;
            StartCoroutine(_GetHit_Callback());
        }

        public void Move(Transform target)
        {
            transform.position = target.position;
        }

        public void Heal(int value)
        {
            health.Restore(value);
        }

        public void AttackNear()
        {
            anim.Play("Slash");

            if (isPlayerInAttackRange) {
                var player = hits[0].gameObject.GetComponent<PlayerActor>();

                if (player) {
                    player.RemoveHealth(5);
                }
            }
        }

        public void AttackFar()
        {
            //lauch someting toward player??
        }
    }
}
