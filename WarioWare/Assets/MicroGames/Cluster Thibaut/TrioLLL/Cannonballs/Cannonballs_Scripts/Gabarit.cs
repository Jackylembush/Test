using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TrioLLL
{
    namespace CannonBalls
    {
        public class Gabarit : MonoBehaviour
        {
            [SerializeField]
            private float baseSpeed;
            [SerializeField]
            private float speedModifier;
            public GameObject Player;
            private Rigidbody2D rb;
            public bool isPlayerOut = true;
            // Start is called before the first frame update
            void Start()
            {
                rb = GetComponent<Rigidbody2D>();
            }

            // Update is called once per frame
            void Update()
            {
                Move();
            }

            private void Move()
            {
                rb.velocity = (Player.transform.position - transform.position).normalized * (baseSpeed * speedModifier);
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