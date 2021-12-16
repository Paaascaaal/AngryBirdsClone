using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockLevels : MonoBehaviour
{
    public Sprite _levelSprite, _lockSprite;
    Image buttonImage;
    Button thisButton;
    Image[] sternImages;
    
    private void OnEnable()
    {
        buttonImage = gameObject.GetComponent<Image>();
        thisButton = gameObject.GetComponent<Button>();
        sternImages = this.GetComponentsInChildren<Image>();
        
        if (PlayerPrefs.GetInt("SterneLvl2") == 3)
        {
            thisButton.interactable = true;
            buttonImage.sprite = _levelSprite;
            thisButton.GetComponentInChildren<Text>().enabled = true;

            foreach (var image in sternImages)
            {
                image.enabled = true;
            }


        }
        else if (PlayerPrefs.GetInt("SterneLvl2") < 3)
        {
            thisButton.interactable = false;
            buttonImage.sprite = _lockSprite;
            thisButton.GetComponentInChildren<Text>().enabled = false;


            for (int i = 1; i < sternImages.Length; i++)
            {
                sternImages[i].enabled = false;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
