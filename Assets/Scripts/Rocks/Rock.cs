using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Rocks {
    public class Rock : MonoBehaviour {
        ParticleSystem ps;
        SpriteRenderer sr;
        CapsuleCollider2D bc2d;
        Rigidbody2D rb2d;

        void Start() {
            ps = GetComponent<ParticleSystem>();
            sr = GetComponent<SpriteRenderer>();
            bc2d = GetComponent<CapsuleCollider2D>();
            rb2d = GetComponent<Rigidbody2D>();
            ps.startColor = sr.color;
        }

        private void Update() {
            if (transform.position.y < -50)
                DieImmediately();
        }

        public void Die() {
            bc2d.enabled = false;
            rb2d.bodyType = RigidbodyType2D.Static;
            ps.startDelay = 0;
            sr.enabled = false;
            GameState.CurrentRound.RocksDead++;
            GameState.Instance.CheckLoss();
            Destroy(gameObject, 1);
        }

        public void DieImmediately() {
            GameState.CurrentRound.RocksDead++;
            GameState.Instance.CheckLoss();
            Destroy(gameObject);
        }
    }
}