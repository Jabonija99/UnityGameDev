using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderSounds : MonoBehaviour
{
    private void OnEnable()
    {
        SoundManager.PlaySound(SoundType.INVADERSOUND);
    }

    public void AttackSound()
    {
        SoundManager.PlaySound(SoundType.INVADERATTACK);
    }
}
