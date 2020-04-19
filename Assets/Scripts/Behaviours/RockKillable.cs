using Rocks;
using UnityEngine;

namespace Behaviours {
    public class RockKillable: MonoBehaviour {
        void OnCollisionEnter2D(Collision2D collision){
            if (collision.gameObject.layer != 8) return;
            var rock = collision.gameObject.GetComponent<Rock>();
            rock.Die();
        }
    }
}