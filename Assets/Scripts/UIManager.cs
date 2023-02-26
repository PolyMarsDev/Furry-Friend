using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI interactionPrompt;
    public TextMeshProUGUI objectiveText;

    public static UIManager Instance;
    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else 
        {
            Instance = this;
        }


        interactionPrompt.enabled = false;
        objectiveText.enabled = false;
    }

    public void setInteractionPromptText(string text)
    {
        interactionPrompt.text = text;
    }
    

    public void setInteractionPromptVisibility(bool visible)
    {
        interactionPrompt.enabled = visible;
    }

    public void setObjectiveText(string text)
    {
        objectiveText.text = text;
    }
    

    public void setObjectiveVisibility(bool visible)
    {
        objectiveText.enabled = visible;
    }
}
