using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Awake()
    {
        // Register this player instance to the global GameManager
        if (GameManager.Instance != null)
        {
            GameManager.Instance.Player = this.gameObject;
        }
    }
}
