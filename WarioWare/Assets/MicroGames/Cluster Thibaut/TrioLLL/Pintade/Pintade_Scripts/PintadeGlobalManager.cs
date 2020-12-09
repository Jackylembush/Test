using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

namespace TrioLLL
{
    namespace Pintade
    {
        /// <summary>
        /// VIDAL Luc
        /// </summary>
        public class PintadeGlobalManager : TimedBehaviour
        {
            private bool inputPressed;
            private bool leftInputActivated;
            private bool rightInputActivated;

            private int leftChoice;
            private int rightChoice;
            public int bigChoice;

            public GameObject leftGrass;
            public GameObject rightGrass;

            public GameObject leftArrow;
            public GameObject rightArrow;

            [HideInInspector] public bool frogEaten;
            [HideInInspector] public bool pintadeEaten;
            [HideInInspector] public bool nothingEaten;


            public override void Start()
            {
                base.Start(); //Do not erase this line!

                bigChoice = Random.Range(0,2);
                Debug.Log(bigChoice);
                inputPressed = false;
                pintadeEaten = false;
                frogEaten = false;
                nothingEaten = false;
                leftInputActivated = false;
                leftChoice = 10;
                rightChoice = 10;
            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

                if (inputPressed == false && leftInputActivated == true || rightInputActivated == true)
                {
                    if (Input.GetKey(KeyCode.LeftArrow) && leftInputActivated == true)
                    {
                        if (leftGrass.GetComponent<TouffeManager>().pintadeON == true)
                        {
                            pintadeEaten = true;
                        }
                        else if (leftGrass.GetComponent<TouffeManager>().pintadeON == false)
                        {
                            if (leftGrass.GetComponent<TouffeManager>().frogON == true)
                            {
                                frogEaten = true;
                            }
                            else if (leftGrass.GetComponent<TouffeManager>().frogON == false)
                            {
                                nothingEaten = true;
                            }
                        }

                        inputPressed = true;
                    }

                    if (Input.GetKey(KeyCode.RightArrow) && rightInputActivated == true)
                    {
                        if (rightGrass.GetComponent<TouffeManager>().pintadeON == true)
                        {
                            pintadeEaten = true;
                        }
                        else if (rightGrass.GetComponent<TouffeManager>().pintadeON == false)
                        {
                            if (rightGrass.GetComponent<TouffeManager>().frogON == true)
                            {
                                frogEaten = true;
                            }
                            else if (rightGrass.GetComponent<TouffeManager>().frogON == false)
                            {
                                nothingEaten = true;
                            }
                        }

                        inputPressed = true;
                    }
                }

            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {
                Debug.Log(Tick);

                if (Tick == 2)
                {
                    switch (currentDifficulty)
                    {
                        case Manager.Difficulty.EASY:
                            EasyTouffeChoice();
                            break;

                        case Manager.Difficulty.MEDIUM:
                            MediumAndHardTouffeChoice();
                            break;

                        case Manager.Difficulty.HARD:
                            MediumAndHardTouffeChoice();
                            break;
                    }
                }

                switch (currentDifficulty)
                {
                    case Manager.Difficulty.EASY:
                        if (Tick == 4)
                        {
                            leftArrow.GetComponent<ArrowInputBehaviour>().activated = true;
                            rightArrow.GetComponent<ArrowInputBehaviour>().activated = true;
                            leftInputActivated = true;
                            rightInputActivated = true;
                        }
                        break;

                    case Manager.Difficulty.MEDIUM:
                        if (Tick == 4)
                        {
                            leftArrow.GetComponent<ArrowInputBehaviour>().activated = true;
                            rightArrow.GetComponent<ArrowInputBehaviour>().activated = true;
                            leftInputActivated = true;
                            rightInputActivated = true;
                        }
                        break;

                    case Manager.Difficulty.HARD:
                        if (Tick == 3)
                        {
                            if (bigChoice == 1)
                            {
                                rightArrow.GetComponent<ArrowInputBehaviour>().activated = true;
                                rightInputActivated = true;
                            }
                            else if (bigChoice == 0)
                            {
                                leftArrow.GetComponent<ArrowInputBehaviour>().activated = true;
                                leftInputActivated = true;
                            }
                        }

                        if (Tick == 5)
                        {
                            if (bigChoice == 1)
                            {
                                leftArrow.GetComponent<ArrowInputBehaviour>().activated = true;
                                leftInputActivated = true;
                            }
                            else if (bigChoice == 0)
                            {
                                rightArrow.GetComponent<ArrowInputBehaviour>().activated = true;
                                rightInputActivated = true;
                            }
                        }
                        break;
                }

                if (Tick == 8)
                {
                    if (pintadeEaten == false && frogEaten == false && nothingEaten == false)
                    {
                        nothingEaten = true;
                    }

                    if (pintadeEaten == true)
                    {
                        Manager.Instance.Result(true);
                    }
                    else if (frogEaten == true)
                    {
                        Manager.Instance.Result(false);
                    }
                    else if (nothingEaten == true)
                    {
                        if (leftGrass.GetComponent<TouffeManager>().pintadeON == true || rightGrass.GetComponent<TouffeManager>().pintadeON == true)
                        {
                            Manager.Instance.Result(false);
                        }
                        else
                        {
                            Manager.Instance.Result(true);
                        }
                    }
                }
            }

            private void EasyTouffeChoice()
            {
                if (bigChoice == 0)
                {
                    leftChoice = leftGrass.GetComponent<TouffeManager>().choice;
                }

                else if (bigChoice == 1)
                {
                    rightChoice = rightGrass.GetComponent<TouffeManager>().choice;
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

            private void MediumAndHardTouffeChoice()
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
        }
    }
}