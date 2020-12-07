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
        public class PintadeGlobalManager : TimedBehaviour
        {
            private bool rightSpawn;
            private bool leftSpawn;

            private int leftChoice;
            private int rightChoice;
            public int bigChoice;

            public GameObject leftGrass;
            public GameObject rightGrass;

            public GameObject leftArrow;
            public GameObject rightArrow;


            public override void Start()
            {
                base.Start(); //Do not erase this line!

                bigChoice = Random.Range(0,2);
            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {
                Debug.Log(Tick);

                if (Tick == 2)
                {
                    if (bigChoice == 0)
                    {
                        leftChoice = leftGrass.GetComponent<TouffeManager>().choice;

                        if (leftChoice == 1)
                        {
                            rightChoice = 2;
                        }
                        else if (leftChoice == 2)
                        {
                            rightChoice = rightGrass.GetComponent<TouffeManager>().choice;
                        }
                    }
                    else if (bigChoice == 1)
                    {
                        rightChoice = rightGrass.GetComponent<TouffeManager>().choice;

                        if (rightChoice == 1)
                        {
                            leftChoice = 2;
                        }
                        else if (rightChoice == 2)
                        {
                            leftChoice = leftGrass.GetComponent<TouffeManager>().choice;
                        }
                    }

                    if (rightChoice == 1)
                    {
                        rightGrass.GetComponent<TouffeManager>().pintadeON = true;

                    }
                    else if (rightChoice == 2)
                    {
                        rightGrass.GetComponent<TouffeManager>().frogON = true;
                    }

                    if (leftChoice == 1)
                    {
                        leftGrass.GetComponent<TouffeManager>().pintadeON = true;
                    }
                    else if (leftChoice == 2)
                    {
                        leftGrass.GetComponent<TouffeManager>().frogON = true;
                    }
                }

                if (Tick == 4)
                {
                    leftArrow.GetComponent<ArrowInputBehaviour>().activated = true;
                    rightArrow.GetComponent<ArrowInputBehaviour>().activated = true;
                }
            }
        }
    }
}