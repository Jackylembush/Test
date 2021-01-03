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
        public class GraphManager : TimedBehaviour
        {
            public GameObject backgroundLevel1;
            public GameObject backgroundLevel2;
            public GameObject backgroundLevel3;
            public GameObject bossLevel1;
            public GameObject bossLevel2;
            public GameObject bossLevel3;
            public GameObject bossLevel1Defeated;
            public GameObject bossLevel2Defeated;
            public GameObject bossLevel3Defeated;
            public GameObject bossLevel1Hand;
            public GameObject bossLevel2Hand;
            public GameObject bossLevel3Hand;
            public ParticleSystem confusedEnemy;
            private float bossLife;
            private bool gameIsWon;

            public override void Start()
            {
                bossLife = GetComponent<EnemyLifeSystem>().enemyLife;
                gameIsWon = GetComponent<EnemyLifeSystem>().victory;
                base.Start();

                    Debug.Log("ça passe ici");
                switch (currentDifficulty)
                {
                    case Difficulty.EASY:
                        backgroundLevel1.SetActive(true);
                        bossLevel1.SetActive(true);
                        break;
                    case Difficulty.MEDIUM:
                        backgroundLevel2.SetActive(true);
                        bossLevel2.SetActive(true);
                        break;
                    case Difficulty.HARD:
                        backgroundLevel3.SetActive(true);
                        bossLevel3.SetActive(true);
                        break;
                }
            }
            public override void TimedUpdate()
            {
                base.TimedUpdate();
                if (Tick >= 7 && bossLife <= 0)
                {
                    confusedEnemy.Play();
                    switch (currentDifficulty)
                    {
                        case Difficulty.EASY:
                            bossLevel1.SetActive(false);
                            bossLevel1Defeated.SetActive(true);
                            break;
                        case Difficulty.MEDIUM:
                            bossLevel2.SetActive(false);
                            bossLevel2Defeated.SetActive(true);
                            break;
                        case Difficulty.HARD:
                            bossLevel3.SetActive(false);
                            bossLevel3Defeated.SetActive(true);
                            break;
                    }
                }
                else if (Tick >= 7 && bossLife > 0)
                {
                    switch (currentDifficulty)
                    {
                        case Difficulty.EASY:
                            bossLevel1.SetActive(false);
                            bossLevel1Hand.SetActive(true);
                            break;
                        case Difficulty.MEDIUM:
                            bossLevel2.SetActive(false);
                            bossLevel2Hand.SetActive(true);
                            break;
                        case Difficulty.HARD:
                            bossLevel3.SetActive(false);
                            bossLevel3Hand.SetActive(true);
                            break;
                    }
                }
                if (Tick == 7)
                {
                }
            }
        }
    }
}
