using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcNameTag : MonoBehaviour
{
    [SerializeField] private Text nameText = null;

    public void SetName(string name)
    {
        nameText.text = name;
    }

    public void Toggle(bool toggle)
    {
        gameObject.SetActive(toggle);
    }
}
