using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrioLLL
{
    namespace Pintade
    {
        public class AnimalBehaviour : TimedBehaviour
        {
            public float standSpeed;
            public float standTime;
            private bool jumped;
            public GameObject leafParticles;

            public override void Start()
            {
                base.Start(); //Do not erase this line!
            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

                if (jumped == false)
                {
                    jumped = true;

                    StartCoroutine(Reveal());
                }
            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {

            }

            IEnumerator Reveal()
            {
                Vector3 originalPos = transform.position; 

                float standDuration = 0;

                Instantiate(leafParticles, transform);

                while (standDuration < standTime)
                {
                    transform.position = new Vector3(originalPos.x, originalPos.y + standSpeed, originalPos.z);

                    standDuration += Time.deltaTime;

                    yield return new WaitForSeconds(0.05f);
                }
            }
        }
    }
}