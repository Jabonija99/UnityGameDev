using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public enum SoundType
{
    PLAYERATTACK,
    PLAYERSTEP1,
    PLAYERSTEP2,
    PLAYERHIT,
    BEARGROWL,
    BONES,
    DOGEAT,
    DOGGROWL,
    BRICKSOUND,
    FENCESOUND,
    EXPLOSION,
    NIGHTSOUND,
    INVADERSOUND,
    PLATEDFOOD,
    SUMMONSOUND,
    ITEMGET,
    DEMONCHANT,
    DEMONATTACK,
    INVADERATTACK
}



[RequireComponent(typeof(AudioSource)), ExecuteInEditMode]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private SoundList[] soundList;

    private static SoundManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(SoundType sound, float volume = 0.5f)
    {
        
        AudioClip clip = instance.soundList[(int)sound]._sound;

        if(clip == null)
        {
            Debug.Log("Failed to play" + sound);
        }

        instance.audioSource.pitch = 1;
        instance.audioSource.PlayOneShot(clip, volume);
    }

    public static void PlayVariedSound(SoundType sound, float volume = 1)
    {
        AudioClip clip = instance.soundList[(int)sound]._sound;
        //instance.audioSource.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
        instance.audioSource.PlayOneShot(clip, volume);
    }

    public static void PlayPitchedSound(SoundType sound, float pitch = 1, float volume = 1)
    {
        AudioClip clip = instance.soundList[(int)sound]._sound;
        instance.audioSource.pitch = pitch;
        instance.audioSource.PlayOneShot(clip, volume);
    }


    public static void PlayLoopingSound(AudioClip loopingClip, SoundType sound, float volume = 0.5f)
    {
        loopingClip = instance.soundList[(int)sound]._sound;
        instance.audioSource.loop = true;
        instance.audioSource.clip = loopingClip;
        instance.audioSource.Play();
    }
    public static void StopLoopingSound(AudioClip loopingClip)
    {
        instance.audioSource.clip = loopingClip;
        instance.audioSource.Stop();
    }

#if UNITY_EDITOR

    private void OnEnable()
    {
        string[] names = Enum.GetNames(typeof(SoundType));
        Array.Resize(ref soundList, names.Length);

        for (int i = 0; i < soundList.Length; i++)
        {
            soundList[i].name = names[i];
        }
    }

#endif

    [Serializable]
    public struct SoundList
    {
        [HideInInspector] public string name;
        [SerializeField] private AudioClip sound;
        public AudioClip _sound { get { return sound; } }

    }


}
