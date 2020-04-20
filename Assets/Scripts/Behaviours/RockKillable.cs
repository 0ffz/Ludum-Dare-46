using Rocks;
using UnityEngine;

namespace Behaviours {
    public class RockKillable: MonoBehaviour {


        public bool isGrounded = false;


        void OnCollisionEnter2D(Collision2D collision){

           
            if (collision.gameObject.layer != 8) return;
            var rock = collision.gameObject.GetComponent<Rock>();
            rock.Die();

            
        }
    }
}