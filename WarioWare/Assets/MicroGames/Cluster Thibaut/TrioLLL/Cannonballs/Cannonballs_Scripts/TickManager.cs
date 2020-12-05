using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrioLLL
{
    namespace CannonBalls
    {
        public class TickManager : TimedBehaviour
        {
            private Gabarit[] gabarits;
            public override void Start()
            {
                base.Start(); //Do not erase this line!
                gabarits = FindObjectsOfType<Gabarit>();
            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {
                if (Tick == 8) 
                {
                    bool win = true;
                    foreach (Gabarit gabarit in gabarits)
                    {
                        if (!gabarit.isPlayerOut) win=false;
                    }
                    Debug.Log(win);
                    //Manager.Instance.Result(win);
                }
            }
        }
    }
}