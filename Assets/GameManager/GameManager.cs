using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   GameManager[] manager;
   
    

    static int score = 0;
    int highScore = 0;

    private void OnEnable()
    {
        manager = FindObjectsOfType<GameManager>();
        if (manager.Length > 1)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public int GetScore()
    {
        return score;
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
    }

    public void ResetScore()
    {
        score = 0;
        
    }

    public void SetHighscore()
    {
        highScore = GetHighscore(0);

        if (score > highScore)
        {
            highScore = score;
        }
        
        //if(SceneManager.GetActiveScene().buildIndex == 2)
        //{
        //    PlayerPrefs.SetInt("HSLvl1", highScore);
        //} else if (SceneManager.GetActiveScene().buildIndex == 3)
        //{
        //    PlayerPrefs.SetInt("HSLvl2", highScore);
        //}else if (SceneManager.GetActiveScene().buildIndex == 4)
        //{
        //    PlayerPrefs.SetInt("HSLvl3", highScore);
        //}

        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 2:
                PlayerPrefs.SetInt("HSLvl1", highScore);
                break;

            case 3:
                PlayerPrefs.SetInt("HSLvl2", highScore);
                break;

            case 4:
                PlayerPrefs.SetInt("HSLvl3", highScore);
                break;
        }
        
        

        
    }

    public int GetHighscore(int levelIndex)
    {

        if (SceneManager.GetActiveScene().buildIndex == 2 || levelIndex == 1)
        {
            highScore = PlayerPrefs.GetInt("HSLvl1", 0);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3 || levelIndex == 2)
        {
            highScore = PlayerPrefs.GetInt("HSLvl2", 0);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4 || levelIndex == 3)
        {
            highScore = PlayerPrefs.GetInt("HSLvl3", 0);
        }

        return highScore;
    }

    public void ResetPlayerPrefs()
    {
        CloseSurePanel();
        PlayerPrefs.DeleteAll();
        LoadLevel(0);
    }

    public void OpenSurePanel()
    {
        GameObject.FindGameObjectWithTag("Sure").GetComponent<Transform>().localPosition = Vector3.zero;
        GameObject.FindGameObjectWithTag("Reset").GetComponent<Button>().interactable = false;
    }

    public void CloseSurePanel()
    {
        GameObject.FindGameObjectWithTag("Sure").GetComponent<Transform>().localPosition = Vector3.left * 5000;
        GameObject.FindGameObjectWithTag("Reset").GetComponent<Button>().interactable = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    
    

}
