using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    [SerializeField] private float waitForFadeIn_Time = 1.0f;
    [SerializeField] private float fadeDuration = 3.0f;

    private void Awake()
    {
        gameObject.GetComponent<Image>().enabled = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitForFade());
    }


    IEnumerator waitForFade()
    {
        yield return new WaitForSeconds(waitForFadeIn_Time);
        gameObject.GetComponent<Image>().CrossFadeAlpha(0f, fadeDuration, true);
        yield return new WaitForSeconds(fadeDuration);
        Destroy(gameObject);
        yield break;
    }
}
