using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    [SerializeField] Image image;
    // Start is called before the first frame update
    void Awake()
    {
        image.gameObject.SetActive(true);
    }
    void Start()
    {
        StartCoroutine("FadeEffect");
    }

    private IEnumerator FadeEffect()
    {
        float fadeCount = 0; //initial alpha value

        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f; //lower alpha value 0.01 per 0.01 second 
            yield return new WaitForSeconds(0.01f); //per 0.01 second
            image.color = new Color(0, 0, 0, 1 - fadeCount); //makes image look transparent  
        }
        yield return null;
    }
}
