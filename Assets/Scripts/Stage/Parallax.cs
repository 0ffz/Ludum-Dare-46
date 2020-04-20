using UnityEngine;

namespace Stage {
    /**
     * Script by Andrei Apanasik under MIT license
     * https://github.com/Suvitruf/unity-parallax
     */
    public class Parallax : MonoBehaviour {
        private Vector3 _startPos;
        private float _length;
        public new GameObject camera;
        public float parallaxEffect;

        void Start() {
            _startPos = transform.position;
            _length = GetComponent<SpriteRenderer>().bounds.size.x;
        }

        void Update() {
            var position = camera.transform.position;
            float temp = position.x * (1 - parallaxEffect);
            float distX = position.x * parallaxEffect;
            float distY = position.y * parallaxEffect;

            transform.position = _startPos + new Vector3(distX, distY, 0);
        }
    }
}