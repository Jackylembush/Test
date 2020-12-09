using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrioLLL
{
    namespace Cannonballs
    {
        public class TrueGabarits : TimedBehaviour
        {
            [SerializeField]
            private float baseSpeed;
            [SerializeField]
            private float speedModifier;
            public GameObject Player;
            private Rigidbody2D rb;
            public bool isPlayerOut = true;
            public bool randomized = false;
            public float min_x = -20f;
            public float max_x = 20f;
            public float min_y = -10f;
            public float max_y = 10f;
            public Vector2 nextPosition;
            public override void Start()
            {
                base.Start(); //Do not erase this line!
                rb = GetComponent<Rigidbody2D>();
                nextPosition = new Vector2(Random.Range(min_x, max_x), Random.Range(min_y, max_y));
            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!
                Move();
            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {

            }

            private void Move()
            {
                if (randomized)
                {
                    if (Vector2.Distance(transform.position, nextPosition) <= 0.01f)
                    {
                        nextPosition = new Vector2(Random.Range(min_x, max_x), Random.Range(min_y, max_y));
                    }
                    transform.position = Vector2.MoveTowards(transform.position, nextPosition, baseSpeed * speedModifier);
                    //Vector2 newDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                    //Debug.Log(newDirection);
                    //rb.velocity = newDirection.normalized * (baseSpeed * speedModifier);
                    //Debug.Log(rb.velocity);
                }
                else
                {
                    rb.velocity = (Player.transform.position - transform.position).normalized * (baseSpeed * speedModifier);
                }


            }
            private void OnTriggerStay2D(Collider2D collision)
            {
                if (collision.tag == "Player")
                    isPlayerOut = false;
                else return;
            }
            private void OnTriggerExit2D(Collider2D collision)
            {
                if (collision.tag == "Player")
                    isPlayerOut = true;
                else return;
            }
        }
    }
}