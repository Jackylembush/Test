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
            public SpriteRenderer backgroundLevel1;
            public SpriteRenderer backgroundLevel2;
            public SpriteRenderer backgroundLevel3;
            public SpriteRenderer bossLevel1;
            public SpriteRenderer bossLevel2;
            public SpriteRenderer bossLevel3;

            public override void Start()
            {
                base.Start();

                switch (currentDifficulty)
                {
                    case Manager.Difficulty.EASY:
                        this.backgroundLevel1 = GetComponent<SpriteRenderer>();
                        this.bossLevel1 = GetComponent<SpriteRenderer>();
                        break;
                    case Manager.Difficulty.MEDIUM:
                        this.backgroundLevel2 = GetComponent<SpriteRenderer>();
                        this.bossLevel2 = GetComponent<SpriteRenderer>();
                        break;
                    case Manager.Difficulty.HARD:
                        this.backgroundLevel3 = GetComponent<SpriteRenderer>();
                        this.bossLevel3 = GetComponent<SpriteRenderer>();
                        break;
                }
            }
        }
    }
}
