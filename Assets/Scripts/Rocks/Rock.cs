using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Rocks {
    public class Rock : MonoBehaviour {
        private void Update() {
            if (transform.position.y < -50)
                Die();
        
        }

        public void Die() {
            GameState.Instance.RocksDead++;
            GameState.Instance.CheckLoss();
            Destroy(gameObject);
        }


    }
}