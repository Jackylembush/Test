using System.Collections;
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
        public class EnemyLifeSystem : TimedBehaviour
        {
            [HideInInspector]public float enemyLife;
            public bool victory = false;
            private AudioSource source;
            public AudioClip victoryClip;
            public AudioClip failClip;
            public bool gameFinished;

            public override void Start()
            {
                source = GetComponent<AudioSource>();
                gameFinished = false;
                base.Start();

                switch (currentDifficulty)
                {
                    case Difficulty.EASY:
                        enemyLife = 12;
                        break;
                    case Difficulty.MEDIUM:
                        enemyLife = 15;
                        break;
                    case Difficulty.HARD:
                        enemyLife = 17;
                        break;
                }
            }

            public void Damage()
            {
                enemyLife--;
                if (enemyLife <= 0)
                {
                    victory = true;
                }
            }

            public override void TimedUpdate()
            {
                base.TimedUpdate();
                if (Tick == 8)
                {
                    gameFinished = true;
                    Manager.Instance.Result(victory);
                }
            }

            public void Update()
            {
                if (gameFinished)
                {
                    if (victory)
                    {
                        source.PlayOneShot(victoryClip);
                    }
                    else
                    {
                        source.PlayOneShot(failClip);
                    }
                }
            }
        }
    }
}
