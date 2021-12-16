using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowStars : MonoBehaviour
{
    Text levelText;
    Image[] sternBilder;
    public Sprite goldStern;
    
    
    // Start is called before the first frame update
    void Start()
    {
        levelText = GetComponentInChildren<Text>();

        sternBilder = GetComponentsInChildren<Image>();

        if (levelText.text == "1")
        {

            for (int i = 0; i < PlayerPrefs.GetInt("SterneLvl1", 0); i++)
            {
                sternBilder[i+1].sprite = goldStern;
            }

        }else if (levelText.text == "2")
        {
            for (int i = 0; i < PlayerPrefs.GetInt("SterneLvl2", 0); i++)
            {
                sternBilder[i+1].sprite = goldStern;
            }

        }
        else if (levelText.text == "3")
        {
            for (int i = 0; i < PlayerPrefs.GetInt("SterneLvl3", 0); i++)
            {
                sternBilder[i+1].sprite = goldStern;
            }

        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
