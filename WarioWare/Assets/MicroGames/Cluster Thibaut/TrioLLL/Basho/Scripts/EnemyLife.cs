using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrioLLL
{
    namespace Basho
    {
        /// <summary>
        /// Louis Vitrant
        /// </summary>
        public class EnemyLife : TimedBehaviour
        {
            public GameObject enemyLevel1;
            public GameObject enemyLevel2;
            public GameObject enemyLevel3;
            public SpriteRenderer backgroundLevel1;
            public SpriteRenderer backgroundLevel2;
            public SpriteRenderer backgroundLevel3;
            public int chosenLevel;
            public float enemyLifeBar;


            public void Start()
            {
                if (chosenLevel == 1)
                {
                    enemyLifeBar = 12;
                    enemyLevel1.SetActive(true);
                    enemyLevel2.SetActive(false);
                    enemyLevel3.SetActive(false);
                    this.backgroundLevel1 = GetComponent<SpriteRenderer>();
                }
                else if(chosenLevel == 2)
                {
                    enemyLifeBar = 15;
                    enemyLevel1.SetActive(false);
                    enemyLevel2.SetActive(true);
                    enemyLevel3.SetActive(false);
                    this.backgroundLevel2 = GetComponent<SpriteRenderer>();
                }
                else if (chosenLevel == 3)
                {
                    enemyLifeBar =17;
                    enemyLevel1.SetActive(false);
                    enemyLevel2.SetActive(false);
                    enemyLevel3.SetActive(true);
                    this.backgroundLevel3 = GetComponent<SpriteRenderer>();
                }
                else
                {
                    enemyLifeBar = 10000;
                    enemyLevel1.SetActive(false);
                    enemyLevel2.SetActive(false);
                    enemyLevel3.SetActive(false);
                }
            }

            public void Damage()
            {
                enemyLifeBar--;
            }

            public void Update()
            {
            }
        }
    }
}
