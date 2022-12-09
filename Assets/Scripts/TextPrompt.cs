using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPrompt : MonoBehaviour
{
    public static TextPrompt instance;

    public GameObject promptArea;
    public Text promptText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        hidePrompt();
    }


    public void showPrompt(string text)
    {
        promptArea.SetActive(true);
        promptText.text = text;
    }

    public void hidePrompt()
    {
        promptArea.SetActive(false);
    }

}
