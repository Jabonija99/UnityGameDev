using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonSounds : MonoBehaviour
{
    [SerializeField] private GameObject bgm;
    private AudioClip clip;
    

    private void OnEnable()
    {
        SoundManager.PlayLoopingSound(clip, SoundType.DEMONCHANT);
    }

    private void OnDisable()
    {
        SoundManager.StopLoopingSound(clip);
        bgm.GetComponent<LevelSounds>().PlayNightSounds();
    }

}
