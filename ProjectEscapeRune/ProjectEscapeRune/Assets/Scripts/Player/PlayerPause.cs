using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPause : MonoBehaviour
{

    private PlayerInputs inputs;
    [SerializeField] private GameObject _pauseMenu;
    private PlayerController _playerController;

    private void Awake()
    {
        inputs = new PlayerInputs();
        inputs.Main.Pause.performed += ctx => PauseGame();
    }

    // Start is called before the first frame update
    void Start()
    {
        _pauseMenu.SetActive(false);
        _playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        Debug.Log("Game Pause");
        _pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        _playerController.canMove = false;
    }

    public void ResumeGame()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        _playerController.canMove = true;
    }

    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }
}
