using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Utility;
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
        switch (type)
        {
            case AttackType.Reaper:
                battleStart.PlayDelayed(0.3f);
                reaperLaughter.Play();
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
            default: print("no boss type set, no sounds will be played");
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
    }
}