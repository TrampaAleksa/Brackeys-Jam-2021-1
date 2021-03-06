﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using _Project.Scripts.Utility;
using NUnit.Framework;
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
    public AudioSource reaperLaughter;
    public AudioSource spiderDeath;
    public AudioSource spiderAttack;
    public AudioSource reaperDeath;

    public AudioSource battleStart;
    public AudioSource spiderBattleStart;
    public AudioSource bossFight1;
    public AudioSource bossFight2;
    public AudioSource bossFight3;
    public AudioSource backgroundSoundtrack;
    public AudioSource backgroundSoundtrackRiver;

    public AudioSource randomAmbientSound1;
    public AudioSource randomAmbientSound2;

    public AudioSource resurrection1;
    public AudioSource resurrection2;
    public AudioSource resurrection3;

    public static AudioHolder Instance;

    private AudioSource[]  _sources;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
       
        _sources = GetComponentsInChildren<AudioSource>();
    }

    private void Start()
    {
        TurnOnBackgroundMusic();
    }

    public void PauseAllSounds()
    {
        foreach (var source in _sources)
        {
            source.Pause();
        }
    }
    public void UnPauseAllSounds()
    {
        foreach (var source in _sources)
        {
            source.UnPause();
        }
    }
    


    public void PlayWarriorAttackSound()
    {
        int rand = Random.Range(0, 100);

        if (rand <= 33)
        {
            if (!warriorAttack1.isPlaying)
                warriorAttack1.Play();
        }
        else if (rand >= 66)
        {
            if (!warriorAttack2.isPlaying)
                warriorAttack2.Play();
        }
        else
        {
            if (!warriorAttackIce.isPlaying)
                warriorAttackIce.Play();
        }
    }

    public void PlayGnomeAttackSound()
    {
        if (!gnomeAttack1.isPlaying) gnomeAttack1.Play();
    }

    public void PlayMageSpellSound()
    {
        int rand = Random.Range(0, 100);

        if (mageSpellcast1.isPlaying || mageSpellcast2.isPlaying) return;

        if (rand <= 50)
        {
            mageSpellcast1.Play();
        }
        else
        {
            mageSpellcast2.Play();
        }
    }

    private AudioSource _currentBossMusic;

    public void PlayBossSounds(AttackType type)
    {
        TurnOffBackgroundMusic();
        switch (type)
        {
            case AttackType.Reaper:
                battleStart.PlayDelayed(0.3f);
                reaperLaughter.PlayDelayed(1.3f);
                PlayBossFight(1);
                break;
            case AttackType.Ice:
                battleStart.PlayDelayed(0.3f);
                golemLaugh.Play();
                PlayBossFight(0);
                break;
            case AttackType.Wind:
                battleStart.PlayDelayed(0.3f);
                golemLaugh.Play();
                PlayBossFight(2);
                break;
            case AttackType.Spider:
                spiderBattleStart.PlayDelayed(0.5f);
                spiderDeath.PlayDelayed(4.5f);
                PlayBossFight(0);
                break;
            default:
                print("no boss type set, no sounds will be played");
                break;
        }
    }

    private void PlayBossFight(int index)
    {
        switch (index)
        {
            case 0:
                bossFight2.Stop();
                bossFight2.volume = 1f;
                bossFight2.PlayDelayed(3f);
                _currentBossMusic = bossFight2;
                break;
            case 1:
                bossFight1.Stop();
                bossFight1.volume = 1f;
                bossFight3.PlayDelayed(3f);
                _currentBossMusic = bossFight3;
                break;
            case 2:
                bossFight3.Stop();
                bossFight3.volume = 1f;
                bossFight3.PlayDelayed(2.3f);
                _currentBossMusic = bossFight3;
                break;
           
        }
    }

    public void TurnOffBossMusic()
    {
        new AudioSourceFader(_currentBossMusic, 4f, 0f).StartFading();
        TurnOnBackgroundMusic();
    }

    public void TurnOnBackgroundMusic()
    {
        new AudioSourceFader(backgroundSoundtrack, 4f, 1f).StartFading();
        new AudioSourceFader(backgroundSoundtrackRiver, 4f, 0.4f).StartFading();
    }
    
    public void TurnOffBackgroundMusic()
    {
        new AudioSourceFader(backgroundSoundtrack, 4f, 0f).StartFading();
        new AudioSourceFader(backgroundSoundtrackRiver, 4f, 0f).StartFading();
    }
    

    public void PlayResurrectionSound()
    {
        int rand = Random.Range(0, 100);

        if (rand <= 33)
        {
            resurrection1.Play();
            return;
        }

        if (rand <= 66)
        {
            resurrection2.Play();
            return;
        }

        resurrection3.Play();
    }
}