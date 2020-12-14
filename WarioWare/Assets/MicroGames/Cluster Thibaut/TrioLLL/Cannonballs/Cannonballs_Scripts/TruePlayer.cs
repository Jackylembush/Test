using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

namespace TrioLLL
{
    namespace Cannonballs

    {
        public class TruePlayer : TimedBehaviour
        {
            [SerializeField]
            private float speed;
            [SerializeField]
            private float speedModifier;
            [SerializeField]
            private float bpmDiviser;
            private Rigidbody2D rb;
            public override void Start()
            {
                speedModifier = bpm/bpmDiviser ;
                base.Start(); //Do not erase this line!
                rb = GetComponent<Rigidbody2D>();
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

                float inputHorizontal = Input.GetAxis("Right_Joystick_X");
                float inputVertical = Input.GetAxis("Right_Joystick_Y");
                rb.velocity = new Vector2(inputHorizontal, inputVertical).normalized * (speed * speedModifier);
            }
        }
    }
}