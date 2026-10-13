using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlateEventTrigger : MonoBehaviour
{
   
    [SerializeField] private GameManagerController _gameManagerController;
    [SerializeField] private GameObject emptyPlate;
    [SerializeField] private GameObject foodPlate;

    void Start()
    {
        emptyPlate.SetActive(true);
        foodPlate.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (_gameManagerController.hasFood == true)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                _gameManagerController.hasFedDog = true;
                Debug.Log("Dog Fed");
                emptyPlate.SetActive(false);
                foodPlate.SetActive(true);
                SoundManager.PlaySound(SoundType.PLATEDFOOD,1f);
                Destroy(this.gameObject);

            }
        }
       

    }

}
