using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalStuff : MonoBehaviour
{
    //Sterne einfügen --> Playerpref für jedes Level anlegen und da Sterne reinpacken und dieses dann übergeben an Levelsterne aber nur, wenn vorherige sternvariable nicht größer ist
    
    GameManager gameManager;
    GameObject[] currentBoxes;
    Text[] scores;
    float percentDestroyed = 0f;
    GameObject obj;
    int erhalteneSterne = 0;
    Image[] sternBilder;
    public Sprite goldStern;
    
    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.FindWithTag("UberWall");
        sternBilder = gameObject.GetComponentsInChildren<Image>();
        gameManager = FindObjectOfType<GameManager>();
        gameObject.GetComponent<CanvasGroup>().alpha = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GatherInfo()
    {
        currentBoxes = GameObject.FindGameObjectsWithTag("Wall");
        

        scores = gameObject.GetComponentsInChildren<Text>();

        scores[1].text = "Score:\n" + gameManager.GetScore();

        scores[2].text = "Highscore:\n" + gameManager.GetHighscore(0);

        if (currentBoxes.Length > 0)
        {
            percentDestroyed = 100f / obj.GetComponent<CheckForRemainingBoxes>().GetBoxesToBeginWith() * currentBoxes.Length;
            percentDestroyed = 100f - percentDestroyed;
        } else { percentDestroyed = 100f; }

        
        
        if (percentDestroyed == 100f)
        {
            for (int i = 1; i < 4; i++)
            {
                sternBilder[i].sprite = goldStern;
            }

            erhalteneSterne = 3;

            SterneSetzen();

        }
        else if (percentDestroyed >= 75f)
        {
            
            for (int i = 1; i < 3; i++)
            {
                sternBilder[i].sprite = goldStern;
            }

            erhalteneSterne = 2;

            SterneSetzen();
        }
        else if (percentDestroyed >= 50f)
        {
            
            for (int i = 1; i < 2; i++)
            {
                sternBilder[i].sprite = goldStern;
            }

            erhalteneSterne = 1;

            SterneSetzen();
        }
        else if (percentDestroyed < 50f)
        {
            erhalteneSterne = 0;
        }
            

    }


    public void ShowEndCanvas()
    {
        GatherInfo();
        gameObject.GetComponent<CanvasGroup>().alpha = 1.0f;
        this.GetComponent<AudioSource>().Play();
    }

    public void SterneSetzen()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2 && erhalteneSterne > PlayerPrefs.GetInt("SterneLvl1", 0))
        {
            PlayerPrefs.SetInt("SterneLvl1", erhalteneSterne);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3 && erhalteneSterne > PlayerPrefs.GetInt("SterneLvl2", 0))
        {
            PlayerPrefs.SetInt("SterneLvl2", erhalteneSterne);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4 && erhalteneSterne > PlayerPrefs.GetInt("SterneLvl3", 0))
        {
            PlayerPrefs.SetInt("SterneLvl3", erhalteneSterne);
        }

        Debug.Log(PlayerPrefs.GetInt("SterneLvl1"));
    }



}
