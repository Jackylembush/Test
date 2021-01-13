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
            public GameObject servalJumpLeft;
            public GameObject servalJumpRight;
            public float time;

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
                        StartCoroutine(SickLeft());
                    }
                    else if (happyServal == true)
                    {
                        StartCoroutine(HappyLeft());
                    }

                    jumped = true;
                }
                else if (jumped == false && rightActivated == true)
                {
                    if (sickServal == true)
                    {
                        StartCoroutine(SickRight());
                    }
                    else if (happyServal == true)
                    {
                        StartCoroutine(HappyRight());
                    }

                    jumped = true;
                }

            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {

            }

            IEnumerator SickLeft ()
            {
                servalBack.SetActive(false);
                servalJumpLeft.SetActive(true);

                yield return new WaitForSeconds(time);

                servalJumpLeft.SetActive(false);
                leftSickServal.SetActive(true);
                leftAnimalParent.SetActive(false);
            }

            IEnumerator HappyLeft ()
            {
                servalBack.SetActive(false);
                servalJumpLeft.SetActive(true);

                yield return new WaitForSeconds(time);

                servalJumpLeft.SetActive(false);
                leftHappyServal.SetActive(true);
                leftAnimalParent.SetActive(false);
            }

            IEnumerator SickRight ()
            {
                servalBack.SetActive(false);
                servalJumpRight.SetActive(true);

                yield return new WaitForSeconds(time);

                servalJumpRight.SetActive(false);
                rightSickServal.SetActive(true);
                rightAnimalParent.SetActive(false);
            }

            IEnumerator HappyRight ()
            {
                servalBack.SetActive(false);
                servalJumpRight.SetActive(true);

                yield return new WaitForSeconds(time);

                servalJumpRight.SetActive(false);
                rightHappyServal.SetActive(true);
                rightAnimalParent.SetActive(false);
            }
        }
    }
}