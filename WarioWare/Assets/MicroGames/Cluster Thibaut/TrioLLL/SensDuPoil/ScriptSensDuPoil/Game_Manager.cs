﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Testing;

namespace LLL
{
    namespace SensDuPoil
    {
        public class Game_Manager : TimedBehaviour
        {
            public enum Catstate { IDLE, NEEDY, PET, HAPPY, ANGRY} //Les différents états du chat

            [Header("Cat Mood")] //Etat actuel du chat
            Catstate currentCatState;

            [Header("Compteur de patpat")]
            public int PetCounter = 0; //Compte le nombre actuel de PatPat

            [Header("Objectif")]
            public int PetObjective; //L'objectif caché de PatPat à atteindre et ne pas dépasser

            public GameObject Hand;
            public Sprite HandNormal;
            public Sprite HandPet;
            public Sprite HandAngry;
            public AudioClip CatAsking;
            public AudioClip CatAttack;
            public AudioClip CatDisapointed;
            public AudioClip CatPurr;
            public AudioClip Fail;
            public AudioClip HumanYell;
            public AudioClip Validation;
            public AudioClip LittleValidation;
            public TrioLLL.SensDuPoil.SoundManager Audiomanager;
            public GameObject heartParticle;
            private List<GameObject> heartObjects;
            public Slider slider;
            public GameObject healthbar;
            public Image hbfill;

            private SpriteRenderer srHand;
            private Animator anim;

            public bool canPet;

            IEnumerator PetTimer(float wait) //Permet au chat de ne pas repasser immédiatement dans l'état Needy (et donc d'éviter le gros spam)
            {
                yield return new WaitForSeconds(wait);
                canPet = true;          
            }
            private void SliderRange()
            {
                slider.value = PetCounter;
            }
            private void SliderMaxRange()
            {
                slider.value = PetCounter;
                slider.maxValue = PetObjective;
            }

            public override void Start()
            {
                base.Start(); //Do not erase this line!

                slider = healthbar.GetComponent<Slider>();
                heartObjects = new List<GameObject>();
                currentCatState = Catstate.IDLE;
                canPet = true;
                anim = GetComponent<Animator>();
                srHand = Hand.GetComponent<SpriteRenderer>();
                switch (currentDifficulty) //Permet de gérer la difficulté; Le nombre de PatPat requis change à chaque fois. C'est un nombre aléatoire dans une plage déterminée.
                {
                    case Difficulty.EASY:
                        PetObjective = Random.Range(10, 12);
                        break;
                    case Difficulty.MEDIUM:
                        PetObjective = Random.Range(13, 15);
                        break;
                    case Difficulty.HARD:
                        PetObjective = Random.Range(15, 17);
                        break;
                }
                Audiomanager.PlaySFX(CatDisapointed, 1);
                SliderMaxRange();
            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!
            }

            //FixedUpdate is called on a fixed time.
            public void Update()
            {
                SliderRange();
                if (Input.GetButtonDown("A_Button") && (canPet == true) && (currentCatState != Catstate.ANGRY)) //Appuier sur le bouton A augmente le compteur de pat pat et déclenche l'état associé
                {
                    canPet = false;
                    PetCounter++;


                    if (PetCounter == PetObjective) //Détermine si l'objectif est atteint ou dépassé
                    {
                        currentCatState = Catstate.HAPPY;
                        Audiomanager.PlaySFX(CatAsking, 1);
                        Audiomanager.PlaySFX2(Validation, 1);
                        StartCoroutine(PetTimer(0.1f));
                    }
                    else if (PetCounter > PetObjective)
                    {
                        currentCatState = Catstate.ANGRY; 
                        Audiomanager.PlaySFX(CatAttack, 1);
                        Audiomanager.PlaySFX2(HumanYell, 1);
                        Audiomanager.PlaySFX(Fail, 1);
                        currentCatState = Catstate.ANGRY;
                        hbfill.color = Color.red;
                        for (int i = heartObjects.Count - 1; i >= 0; i--)
                        {
                            Destroy(heartObjects[i]);
                        }
                    }
                    else if (PetCounter < PetObjective)
                    {
                        heartObjects.Add(Instantiate(heartParticle));

                        if(PetCounter == 1)
                        {
                            currentCatState = Catstate.NEEDY;
                        }
                        else
                        {
                            currentCatState = Catstate.PET;
                            anim.Play("Chat_Pet", -1, 0f);
                            Audiomanager.PlaySFX(CatPurr, 5);
                            Audiomanager.PlaySFX2(LittleValidation, 2);
                        }
                        StartCoroutine(PetTimer(0.1f));
                    }
                }
                anim.SetInteger("State", (int)currentCatState);

                switch (currentCatState) //Permet de transitionner entre les différents états du chat
                {
                    case Catstate.IDLE:
                        srHand.sprite = HandNormal;
                        break;
                    case Catstate.NEEDY: //Le chat réclame des PatPat
                        srHand.sprite = HandNormal;
                        //Afficher les sprites du chat needy
                        break;

                    case Catstate.PET: //Le chat reçois des PatPat
                        srHand.sprite = HandPet;
                        //Afficher les sprites du pat pat
                        //Son de ronron
                        break;

                    case Catstate.HAPPY: //Le chat est heureux
                        //Son de chat content
                        break;
                    case Catstate.ANGRY: //Le chat a recu trop de PatPat
                        srHand.sprite = HandAngry;
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
                        Manager.Instance.Result(win);
                    }
                    else if (currentCatState == Catstate.PET || currentCatState == Catstate.IDLE || currentCatState == Catstate.NEEDY)
                    {
                        Audiomanager.PlaySFX(Fail, 1);
                    }
                }
            }
        }
    }
}