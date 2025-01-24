using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class BubbleProjectile : MonoBehaviour
    {
        private Rigidbody2D rigidbody;
        private float xSeconds = 0.5f;
        private bool facingLeft = true;
        public GameManager gameManager;

        // Start is called before the first frame update
        void Start()
        {
            gameManager = GameObject.Find("GameManagerEmpty").GetComponent<GameManager>();
            rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.velocity = gameManager.facingRight ? new Vector3(10f, 0f, 0f) : new Vector3(-10f, 0f, 0f);
            Destroy(gameObject, xSeconds);

        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                gameObject.SetActive(false);
                Destroy(gameObject, 0);
            }
        }

    }
}

