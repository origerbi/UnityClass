using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    private bool keyIsPickedUp = false;
    public static Vector3 spawnPoint;
    public GameObject player;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            if(transform.parent != null)
                transform.parent = null;
                
            instance = this;
            spawnPoint = player.transform.position;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                player.transform.position = spawnPoint;
                player.transform.Rotate(0, -90, 0);
            }
        }
        TextPrompt.instance.hidePrompt();
    }

    public void KeyPickedUp()
    {
        keyIsPickedUp = true;
        player.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
    }

    public bool KeyWithPlayer()
    {
        return keyIsPickedUp;
    }


    public void KeyUsed()
    {
        keyIsPickedUp = false;
        player.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
    }
}
