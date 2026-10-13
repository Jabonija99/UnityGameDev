using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearSounds : MonoBehaviour
{
    private void OnEnable()
    {
        SoundManager.PlaySound(SoundType.BEARGROWL);
    }
}
