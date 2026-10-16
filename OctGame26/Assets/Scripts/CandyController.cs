using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyController : MonoBehaviour
{
    public int value = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<PlayerCandy>())
            {
                other.gameObject.GetComponent<PlayerCandy>().AddCandy(value);
                Destroy(this.gameObject);
            }
        }
    }
}
