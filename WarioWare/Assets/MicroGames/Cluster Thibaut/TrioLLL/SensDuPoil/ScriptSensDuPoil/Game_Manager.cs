using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

namespace LLL
{
    namespace SensDuPoil
    {
        public class Game_Manager : TimedBehaviour
        {
            public enum Catstate { NEEDY, HAPPY, ANGRY, PET } //Les différents états du chat

            [Header("Cat Mood")] //Etat actuel du chat
            Catstate currentCatState;

            [Header("Compteur de patpat")]
            public int PetCounter = 0; //Compte le nombre actuel de PatPat

            [Header("Objectif")]
            public int PetObjective; //L'objectif caché de PatPat à atteindre et ne pas dépasser

            public Sprite Needy;
            public Sprite Pet;
            public Sprite Happy;
            public Sprite Angry;

            public bool canPet;

            IEnumerator PetTimer(float wait) //Permet au chat de ne pas repasser immédiatement dans l'état Needy (et donc d'éviter le gros spam)
            {
                yield return new WaitForSeconds(wait);
                if(currentCatState == Catstate.PET)
                {
                    currentCatState = Catstate.NEEDY;
                }
                canPet = true;
          
            }

            public override void Start()
            {
                base.Start(); //Do not erase this line!
                currentCatState = Catstate.NEEDY;
                canPet = true;

                switch (currentDifficulty) //Permet de gérer la difficulté; Le nombre de PatPat requis change à chaque fois. C'est un nombre aléatoire dans une plage déterminée.
                {
                    case Difficulty.EASY:
                        PetObjective = Random.Range(3, 5);
                        break;
                    case Difficulty.MEDIUM:
                        PetObjective = Random.Range(5, 7);
                        break;
                    case Difficulty.HARD:
                        PetObjective = Random.Range(7, 10);
                        break;
                }
            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

                if (Input.GetButton("A_Button") && (canPet == true) && (currentCatState == Catstate.NEEDY || currentCatState == Catstate.HAPPY)) //Appuier sur le bouton A augmente le compteur de pat pat et déclenche l'état associé
                {
                    canPet = false;
                    Debug.Log(currentCatState);
                    PetCounter++;


                    if (PetCounter == PetObjective) //Détermine si l'objectif est atteint ou dépassé
                    {
                        Debug.Log("Hello There");
                        currentCatState = Catstate.HAPPY;
                        StartCoroutine(PetTimer(0.5f));
                    }
                    else if (PetCounter > PetObjective)
                    {
                        currentCatState = Catstate.ANGRY;
                    }
                    else if (PetCounter < PetObjective)
                    {
                        currentCatState = Catstate.PET;
                        StartCoroutine(PetTimer(0.5f));
                    }
                }
                switch (currentCatState) //Permet de transitionner entre les différents états du chat
                {
                    case Catstate.NEEDY: //Le chat réclame des PatPat

                        gameObject.GetComponent<SpriteRenderer>().sprite = Needy;

                        //Afficher les sprites du chat needy
                        break;

                    case Catstate.PET: //Le chat reçois des PatPat
                        gameObject.GetComponent<SpriteRenderer>().sprite = Pet;
                        Debug.Log(currentCatState);
                        //Afficher les sprites du pat pat
                        //Son de ronron
                        break;

                    case Catstate.HAPPY: //Le chat est heureux
                        Debug.Log(currentCatState);
                        gameObject.GetComponent<SpriteRenderer>().sprite = Happy;
                        //Son de chat content
                        break;

                    case Catstate.ANGRY: //Le chat a recu trop de PatPat
                        gameObject.GetComponent<SpriteRenderer>().sprite = Angry;
                        //Son de chat pas content
                        break;

                }
            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {
                if (Tick == 8)
                {
                    if (currentCatState == Catstate.HAPPY) //Si au dernier tick le chat est dans l'état heureux, c'est gagné
                    {
                        bool win = true;
                        Debug.Log("win");
                        Manager.Instance.Result(win);
                    }
                }
            }
        }
    }
}