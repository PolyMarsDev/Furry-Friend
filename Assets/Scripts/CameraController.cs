using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{

    [SerializeField] Image image;
    [SerializeField] float speed;

    float xRot;
    float yRot;

    public float startingRotY;

    Ray RayOrigin;
    RaycastHit HitInfo;

    bool lockView;
    GameObject targetObject;

    int pillCount = 0;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        lockView = false;

        startingRotY = transform.localEulerAngles.y;

    }
    void Update()
    {

        if (!lockView)
        {
            xRot -= Input.GetAxisRaw("Mouse Y") * speed;
            yRot += Input.GetAxisRaw("Mouse X") * speed;
            xRot = Mathf.Clamp(xRot, -90, 90);
        }


        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out HitInfo, 100.0f))
        {
            if (HitInfo.transform.gameObject.tag == "Interactable" || HitInfo.transform.gameObject.tag == "Pill" || HitInfo.transform.gameObject.tag == "LeftMonitor")
            {
                if (HitInfo.transform.gameObject.GetComponent<InteractionMessage>() != null)
                {
                    string text = HitInfo.transform.gameObject.GetComponent<InteractionMessage>().Text;
                    UIManager.Instance.setInteractionPromptText(text);
                    UIManager.Instance.setInteractionPromptVisibility(true);
                }
                else
                {
                    UIManager.Instance.setInteractionPromptVisibility(false);
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    // if (lockView)
                    // {
                    //     lockView = false;
                    // }
                    // else
                    // {
                    //     lockView = true;
                    //     targetObject = HitInfo.transform.gameObject;
                    // }
                    if (HitInfo.transform.gameObject.GetComponent<AnimationTrigger>() != null)
                    {
                        HitInfo.transform.gameObject.GetComponent<AnimationTrigger>().Trigger();
                    }
                    if (HitInfo.transform.gameObject.tag == "Pill")
                    {
                        Destroy(HitInfo.transform.gameObject);
                        pillCount++;
                        UIManager.Instance.setObjectiveText("Consume Your Height Enhancing Pills (" + pillCount + "/8)");
                        if (!UIManager.Instance.objectiveText.enabled)
                        {
                            UIManager.Instance.objectiveText.enabled = true;
                            //playSound
                        }
                         SoundManager.Instance.PlayConsume();
                        if (pillCount == 8)
                        {
                            StartCoroutine("FadeEffect");
                        }
                    }
                    if (HitInfo.transform.gameObject.tag == "LeftMonitor")
                    {
                        HitInfo.transform.gameObject.GetComponent<InteractionMessage>().Text = "You can't quit. You are addicted.";
                    }
                }
            }
            else
            {
                UIManager.Instance.setInteractionPromptVisibility(false);
            }
        }
    
    }

    void LateUpdate()
    {
        // if (!lockView)
        // {
            transform.eulerAngles = new Vector3(0, yRot + startingRotY, 0);
            transform.GetChild(0).transform.localEulerAngles = new Vector3(xRot, 0, 0);
        // }
        // else
        // {
        //     SmoothLookAt(targetObject.transform.position - transform.position);
        //     xRot = transform.eulerAngles.x;
        //     yRot = transform.eulerAngles.y;
        // }
    }

    void SmoothLookAt(Vector3 newDirection)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newDirection), Time.deltaTime*10);
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
         SceneManager.LoadScene(1);

    }

}
