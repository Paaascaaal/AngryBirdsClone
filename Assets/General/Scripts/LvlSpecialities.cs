using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlSpecialities : MonoBehaviour
{
    
    static int lvl1Birds, lvl2Birds, lvl3Birds;

    // Start is called before the first frame update
    void Start()
    {
        lvl1Birds = 15;
        lvl2Birds = 10;
        lvl3Birds = 8;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetLevelBirds()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2) { return lvl1Birds; }
        else if (SceneManager.GetActiveScene().buildIndex == 3) { return lvl2Birds; }
        else if (SceneManager.GetActiveScene().buildIndex == 4) { return lvl3Birds; }
        else return 0;
    }

    public void MinusLvlBirds()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        { lvl1Birds--; }
        else if (SceneManager.GetActiveScene().buildIndex == 3) { lvl2Birds--; }
        else if (SceneManager.GetActiveScene().buildIndex == 4) { lvl3Birds--; }
    }

    public void ResetBirdCount()
    {
        lvl1Birds = 15;
        lvl2Birds = 10;
        lvl3Birds = 8;
    }
}
