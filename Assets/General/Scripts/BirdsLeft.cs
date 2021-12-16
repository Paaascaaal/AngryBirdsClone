using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdsLeft : MonoBehaviour
{
    Text birdsLeft;
    GameObject obj;
    GameObject obj1;
    int i = 0;
    public float waitTimeForEndCanvas = 2f;
    

    // Start is called before the first frame update
    void Start()
    {
        obj1 = GameObject.FindWithTag("Ende");
        obj = GameObject.FindWithTag("Special");
        obj.GetComponent<LvlSpecialities>();
        
        birdsLeft = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (obj.GetComponent<LvlSpecialities>().GetLevelBirds() > 0 && i == 0)
        {
            birdsLeft.text = "birds left: " + ((obj.GetComponent<LvlSpecialities>().GetLevelBirds())-1);
        }else
        {
            i++;
            birdsLeft.text = "no birds left :( return to the main menu and start anew! <3";
        }

        if (i == 1)
        {
            StartCoroutine(waitForEndCanvas());
        }
    }

    IEnumerator waitForEndCanvas()
    {
        yield return new WaitForSeconds(waitTimeForEndCanvas);
        obj1.GetComponent<FinalStuff>().ShowEndCanvas();
        yield break;
    }
}
