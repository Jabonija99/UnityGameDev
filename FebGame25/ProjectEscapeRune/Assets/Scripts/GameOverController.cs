using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{

    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject _gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        _gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        EnableGameOver();
    }

    private void EnableGameOver()
    {
        if(_playerController.playerCurrentHealth <= 0)
        {
            _gameOverScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }


}
