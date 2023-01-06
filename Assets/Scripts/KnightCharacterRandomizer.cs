using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightCharacterRandomizer : MonoBehaviour
{
    private void Start()
    {
        SkinnedMeshRenderer[] skinMeshes = GetComponentsInChildren<SkinnedMeshRenderer>(true);
        int randomIndex = Random.Range(0, skinMeshes.Length);
        skinMeshes[randomIndex].gameObject.SetActive(true);
    }
}
