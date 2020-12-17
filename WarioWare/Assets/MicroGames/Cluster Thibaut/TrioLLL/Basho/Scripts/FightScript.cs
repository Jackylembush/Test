﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

namespace TrioLLL
{
    namespace Basho
    {
        /// <summary>
        /// Louis Vitrant
        /// </summary>
        public class FightScript : TimedBehaviour
        {
            public GameObject leftRestedArm;
            public GameObject rightRestedArm;
            public GameObject leftActivateddArm;
            public GameObject rightActivatedArm;
            public float hitDuration;
            public bool leftArmIsActivated = false;
            public bool rightArmIsActivated = false;
            public bool canUseLeftArm = true;
            public bool canUseRightArm = true;
            private AudioSource source;
            public AudioClip leftPunch;
            public AudioClip rightPunch;
            public EnemyLifeSystem enemyLife;
            public bool gameIsOver;

            public override void Start()
            {
                base.Start();
                leftRestedArm.SetActive(true);
                rightRestedArm.SetActive(true);
                rightActivatedArm.SetActive(false);
                leftActivateddArm.SetActive(false);
                hitDuration = 60 / bpm / 5;
                source = GetComponent<AudioSource>();
                gameIsOver = GetComponent<EnemyLifeSystem>().gameFinished;
            }

            public override void FixedUpdate()
            {
                base.FixedUpdate();
            }

            public void Update()
            {
                if (!gameIsOver)
                {
                    if (Input.GetButtonDown("Left_Bumper") && canUseLeftArm)
                    {
                        StartCoroutine(ActivationLeftArm());
                    }

                    if (Input.GetButtonDown("Right_Bumper") && canUseRightArm)
                    {
                        StartCoroutine(ActivationRightArm());
                    }

                    if (leftArmIsActivated == true)
                    {
                        leftActivateddArm.SetActive(true);
                        leftRestedArm.SetActive(false);
                        canUseLeftArm = false;
                    }
                    else
                    {
                        leftActivateddArm.SetActive(false);
                        leftRestedArm.SetActive(true);
                        canUseLeftArm = true;
                    }

                    if (rightArmIsActivated == true)
                    {
                        rightActivatedArm.SetActive(true);
                        rightRestedArm.SetActive(false);
                        canUseRightArm = false;
                    }
                    else
                    {
                        rightActivatedArm.SetActive(false);
                        rightRestedArm.SetActive(true);
                        canUseRightArm = true;
                    }
                }
            }

            IEnumerator ActivationLeftArm()
            {
                leftArmIsActivated = true;
                enemyLife.Damage();
                source.PlayOneShot(leftPunch);
                yield return new WaitForSeconds(hitDuration);
                leftArmIsActivated = false;
            }

            IEnumerator ActivationRightArm()
            {
                rightArmIsActivated = true;
                enemyLife.Damage();
                source.PlayOneShot(rightPunch);
                yield return new WaitForSeconds(hitDuration);
                rightArmIsActivated = false;
            }
        }
    }
}