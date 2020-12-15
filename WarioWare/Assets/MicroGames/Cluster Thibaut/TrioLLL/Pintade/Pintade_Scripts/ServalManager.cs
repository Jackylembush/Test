using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrioLLL
{
    namespace Pintade
    {
        /// <summary>
        /// VIDAL Luc
        /// </summary>
        public class ServalManager : TimedBehaviour
        {
            [HideInInspector] public bool leftActivated;
            [HideInInspector] public bool rightActivated;
            [HideInInspector] public bool sickServal;
            [HideInInspector] public bool happyServal;
            private bool jumped;
            public GameObject leftSickServal;
            public GameObject rightSickServal;
            public GameObject leftHappyServal;
            public GameObject rightHappyServal;
            public GameObject servalBack;
            public GameObject leftAnimalParent;
            public GameObject rightAnimalParent;

            public override void Start()
            {
                base.Start(); //Do not erase this line!

                leftActivated = false;
                rightActivated = false;
                sickServal = false;
                happyServal = false;
                jumped = false;
            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

                if (jumped == false && leftActivated == true)
                {
                    if (sickServal == true)
                    {
                        leftSickServal.SetActive(true);
                        servalBack.SetActive(false);
                        leftAnimalParent.SetActive(false);
                    }
                    else if (happyServal == true)
                    {
                        leftHappyServal.SetActive(true);
                        servalBack.SetActive(false);
                        leftAnimalParent.SetActive(false);
                    }

                    jumped = true;
                }
                else if (jumped == false && rightActivated == true)
                {
                    if (sickServal == true)
                    {
                        rightSickServal.SetActive(true);
                        servalBack.SetActive(false);
                        rightAnimalParent.SetActive(false);
                    }
                    else if (happyServal == true)
                    {
                        rightHappyServal.SetActive(true);
                        servalBack.SetActive(false);
                        rightAnimalParent.SetActive(false);
                    }

                    jumped = true;
                }

            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {

            }
        }
    }
}