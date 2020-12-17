using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;
using UnityEngine.UIElements;

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

            public override void Start()
            {
                base.Start();

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
        }
    }
}
