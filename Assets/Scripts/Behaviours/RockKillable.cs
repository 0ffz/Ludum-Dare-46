using Rocks;
using UnityEngine;

namespace Behaviours {
    public class RockKillable: MonoBehaviour {
        private void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.layer != 8) return;
            var rock = other.GetComponent<Rock>();
            rock.Die();
        }
    }
}