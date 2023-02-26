using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JumpscareHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public Image image;
    void Start()
 {
        Invoke("Reload", 2);
    }

    public void Reload()
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
            image.color = new Color(0, 0, 0, fadeCount); //makes image look transparent  
        }
        //after while loop ends, load EndingCredit scene
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
