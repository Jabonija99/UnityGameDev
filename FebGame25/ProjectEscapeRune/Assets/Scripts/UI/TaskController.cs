using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskController : MonoBehaviour
{

    [SerializeField] private GameManagerController _gameManager;
    [SerializeField] private TextMeshProUGUI _dogText;
    [SerializeField] private TextMeshProUGUI _wallText;
    [SerializeField] private TextMeshProUGUI _perimeterText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        CheckTasks();
    }

    private void CheckTasks()
    {
        if (_gameManager.hasFedDog)
        {
            _dogText.fontStyle = FontStyles.Strikethrough;
        }

        if (_gameManager.hasKilledIntruder)
        {
            _perimeterText.fontStyle = FontStyles.Strikethrough;
        }

        if (_gameManager.hasFixedWall)
        {
            _wallText.fontStyle = FontStyles.Strikethrough;
        }
    }
}
