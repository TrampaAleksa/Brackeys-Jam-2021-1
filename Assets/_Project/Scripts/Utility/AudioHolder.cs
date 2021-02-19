﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioHolder : MonoBehaviour
{
    public AudioSource warriorAttack1;
    public AudioSource warriorAttack2;
    public AudioSource warriorAttackIce;
    public AudioSource gnomeAttack1;
    public AudioSource mageSpellcast1;
    public AudioSource mageSpellcast2;
    
    public AudioSource earthGolemDeath;
    public AudioSource earthGolemGrowl;
    public AudioSource golemLaugh;
    public AudioSource iceGolemAttack;
    public AudioSource reaperAttack;
    public AudioSource tornadoSounds;
    
    public AudioSource battleStart;
    public AudioSource bossFight1;
    public AudioSource bossFight2;
    public AudioSource bossFight3;

    public AudioSource randomAmbientSound1;
    public AudioSource randomAmbientSound2;

    public static AudioHolder Instance;

    private void Awake()
    {
        Instance = this;
    }


    public void PlayWarriorAttackSound()
    {
        int rand = Random.Range(0, 100);

        if (rand <= 33)
            warriorAttack1.Play();
        else if (rand >= 66)
            warriorAttack2.Play();
        else warriorAttackIce.Play();
    }
    
    
}
