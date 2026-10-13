using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonSounds : MonoBehaviour
{
    private void OnEnable()
    {
        SoundManager.PlaySound(SoundType.SUMMONSOUND);
    }
}
