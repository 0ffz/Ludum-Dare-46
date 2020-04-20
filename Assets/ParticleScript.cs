using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour {
    ParticleSystem ps;

    // Start is called before the first frame update
    void Start() {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        ps = GetComponent<ParticleSystem>();
        ps.Play();
        Invoke("Remove", 1f);
    }

    void Remove() {
        Destroy(gameObject);
    }
}