using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCandy : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI candyText;
    private int candyCount = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCandy(int value)
    {
        candyCount += value;
        UpdateText();
    }

    private void UpdateText()
    {
        candyText.text = "Candy: " + candyCount.ToString();
    }
}
