using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class EnemyAI : MonoBehaviour
    {
        public float moveSpeed = 1f; 
        public LayerMask ground;
        public LayerMask wall;

        private Rigidbody2D rigidbody; 
        public Collider2D triggerCollider;
        private SpriteRenderer sprite;

        private int health = 50;

        private bool justDamaged = false;
        private float timeElapsed = 0;
        
        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            sprite = GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);
        }

        void FixedUpdate()
        {
            if (justDamaged)
            {
                timeElapsed += Time.deltaTime;

            }

            if (timeElapsed >= 0.125f)
            {
                justDamaged = false;
                sprite.color = new Color(255, 255, 255);
            }

            if(!triggerCollider.IsTouchingLayers(ground) || triggerCollider.IsTouchingLayers(wall))
            {
                Flip();
            }
        }
        
        private void Flip()
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            moveSpeed *= -1;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Bubble Projectile")
            {
                health -= 1;
                sprite.color = new Color(255,0,0);
                justDamaged = true;
                timeElapsed = 0;

                if (health == 0)
                {
                    gameObject.SetActive(false);
                    Destroy(gameObject, 0);
                }
            }
        }


    }
}
