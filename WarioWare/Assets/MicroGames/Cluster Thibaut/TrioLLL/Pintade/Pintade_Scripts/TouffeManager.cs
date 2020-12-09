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
        public class TouffeManager : TimedBehaviour
        {
            public float duration;
            public float magnitude;

            public GameObject frog;
            public GameObject pintade;
            public GameObject animalsParent;
            public GameObject manager;
            public int side;


            [HideInInspector] public int choice;
            [HideInInspector] public bool pintadeON;
            [HideInInspector] public bool frogON;

            public override void Start()
            {
                base.Start(); //Do not erase this line!

                choice = 0;
                pintadeON = false;
                frogON = false;
            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {
                base.TimedUpdate();

                if(Tick == 1)
                {
                    choice = Random.Range(1, 3);
                }

                switch (currentDifficulty)  //Shake des Touffes.
                {
                    case Manager.Difficulty.EASY:
                        if (Tick <= 3)
                        {
                            StartCoroutine(Shake(magnitude, duration));
                        }
                        break;

                    case Manager.Difficulty.MEDIUM:
                        if (Tick <= 3)
                        {
                            StartCoroutine(Shake(magnitude, duration));
                        }
                        break;

                    case Manager.Difficulty.HARD:
                        if (side == manager.GetComponent<PintadeGlobalManager>().bigChoice)
                        {
                            if (Tick <= 2)
                            {
                                StartCoroutine(Shake(magnitude, duration));
                            }
                        }
                        else if (side != manager.GetComponent<PintadeGlobalManager>().bigChoice)
                        {
                            if (Tick <= 4)
                            {
                                StartCoroutine(Shake(magnitude, duration));
                            }
                        }
                        break;
                }


                switch (currentDifficulty)
                {
                    case Manager.Difficulty.EASY:
                        if (Tick == 4)
                        {
                            if (pintadeON == true)
                            {
                                animalsParent.SetActive(true);
                                pintade.SetActive(true);
                            }
                            else if (frogON == true)
                            {
                                animalsParent.SetActive(true);
                                frog.SetActive(true);
                            }
                        }
                        break;

                    case Manager.Difficulty.MEDIUM:
                        if (Tick == 4)
                        {
                            if (pintadeON == true)
                            {
                                animalsParent.SetActive(true);
                                pintade.SetActive(true);
                            }
                            else if (frogON == true)
                            {
                                animalsParent.SetActive(true);
                                frog.SetActive(true);
                            }
                        }
                        break;

                    case Manager.Difficulty.HARD:
                        if (side == manager.GetComponent<PintadeGlobalManager>().bigChoice)
                        {
                            if (Tick == 3)
                            {
                                if (pintadeON == true)
                                {
                                    animalsParent.SetActive(true);
                                    pintade.SetActive(true);
                                }
                                else if (frogON == true)
                                {
                                    animalsParent.SetActive(true);
                                    frog.SetActive(true);
                                }
                            }
                        }
                        else if (side != manager.GetComponent<PintadeGlobalManager>().bigChoice)
                        {
                            if (Tick == 5)
                            {
                                if (pintadeON == true)
                                {
                                    animalsParent.SetActive(true);
                                    pintade.SetActive(true);
                                }
                                else if (frogON == true)
                                {
                                    animalsParent.SetActive(true);
                                    frog.SetActive(true);
                                }
                            }
                        }
                        break;
                }

                if (Tick == 6)
                {
                    if (pintadeON == true)
                    {
                        Debug.Log("pintadeON");
                    }
                    if (frogON == true)
                    {
                        Debug.Log("frogON");
                    }
                }
            }

            IEnumerator Shake(float magnitude, float duration) //Coroutine de Shake des Touffes.
            {

                Vector3 originalPos = transform.localPosition;

                float elapsed = 0.0f;

                while (elapsed < duration)
                {
                    float x = Random.Range(-1f, 1f) * magnitude;

                    transform.position = new Vector3(originalPos.x + x, originalPos.y, originalPos.z);

                    elapsed += Time.deltaTime;

                    yield return null; 
                }

                transform.position = originalPos;
            }
        }
    }
}