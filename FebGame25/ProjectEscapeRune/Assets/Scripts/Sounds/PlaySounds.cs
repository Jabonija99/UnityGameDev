using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySounds : MonoBehaviour
{
    public void Step1Sound()
    {
        SoundManager.PlayVariedSound(SoundType.PLAYERSTEP1, 0.2f);
    }

    public void Step2Sound()
    {
        SoundManager.PlayVariedSound(SoundType.PLAYERSTEP2, 0.2f);
    }

    public void AttackSound()
    {
        SoundManager.PlayVariedSound(SoundType.PLAYERATTACK);
    }

    public void BearGrowlSound()
    {
        SoundManager.PlayVariedSound(SoundType.BEARGROWL);
    }

    public void BoneSound()
    {
        SoundManager.PlayVariedSound(SoundType.BONES);
    }

    public void DogEatSound()
    {
        SoundManager.PlayVariedSound(SoundType.DOGEAT);
    }

    public void DogGrowlSound()
    {
        SoundManager.PlayVariedSound(SoundType.DOGGROWL);
    }

    public void BrickSound()
    {
        SoundManager.PlayVariedSound(SoundType.BRICKSOUND);
    }

    public void FenceSound()
    {
        SoundManager.PlayVariedSound(SoundType.FENCESOUND);
    }

    public void ExplosionSound()
    {
        SoundManager.PlayVariedSound(SoundType.EXPLOSION);
    }

    public void DemonAttackSound()
    {
        SoundManager.PlaySound(SoundType.DEMONATTACK);
    }

    public void PlayerAttackSound()
    {
        SoundManager.PlaySound(SoundType.PLAYERATTACK);
    }
}
