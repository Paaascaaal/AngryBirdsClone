using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    Text[] scoreTexts;

    GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        scoreTexts = GetComponentsInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreTexts[0].text = "Score: " + gameManager.GetScore();
        scoreTexts[1].text = "Highscore: " + gameManager.GetHighscore(0);
    }
}
