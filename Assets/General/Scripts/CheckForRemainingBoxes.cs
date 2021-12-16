using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckForRemainingBoxes : MonoBehaviour
{
    GameObject[] boxes;
    int boxesToBeginWith;

    GameObject obj;
    
    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.FindWithTag("Ende");

        boxes = GameObject.FindGameObjectsWithTag("Wall");
        boxesToBeginWith = boxes.Length;
        

        StartCoroutine(checkBoxes());

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool noBoxesLeft()
    {
        boxes = GameObject.FindGameObjectsWithTag("Wall");
        


        if (boxes.Length > 0)
        {
            return false;

        }
        else
        {
            
            return true;
        }
    }

    IEnumerator checkBoxes()
    {
        while (noBoxesLeft() == false)
        {
            yield return new WaitForSeconds(2f);

            noBoxesLeft();

        }
        obj.GetComponent<FinalStuff>().ShowEndCanvas();
        yield break;
    }

    public int GetBoxesToBeginWith()
    {
        return boxesToBeginWith;
    }
}
