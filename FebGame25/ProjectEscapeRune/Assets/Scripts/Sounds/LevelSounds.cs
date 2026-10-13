using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSounds : MonoBehaviour
{
    private AudioClip _clip;
    private bool isPlaying = false;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (!isPlaying)
        {
            PlayNightSounds();
            isPlaying = true;
        }
    }

    public void PlayNightSounds()
    {
        SoundManager.PlayLoopingSound(_clip, SoundType.NIGHTSOUND);
    }
}
