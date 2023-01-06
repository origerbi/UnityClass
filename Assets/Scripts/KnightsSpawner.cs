using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

public class KnightsSpawner : MonoBehaviour
{
    [SerializeField] private KnightController knightPrefab = null;
    [SerializeField] private int knightsCount = 10;
    [SerializeField] private float spawnRadius = 10f;

    [SerializeField]
    private string[] knightNames = {
        "Sir Lancelot",
        "Sir Gawain",
        "Sir Percival",
        "Sir Galahad",
        "Sir Tristan",
        "Sir Bors",
        "Sir Kay",
        "Sir Bedivere",
        "Sir Gareth",
        "Sir Galahad"
    };

    private void Start()
    {
        SpawnKnights();
    }

    private void SpawnKnights()
    {
        for (int i = 0; i < knightsCount; i++)
        {
            if (!TryGetRandomPositionOnNavMesh(out Vector3 randomPosition))
            {
                i--;
                continue;
            }

            KnightController knight = Instantiate(knightPrefab, randomPosition, Quaternion.identity, transform);
            knight.SetName(GetRandoName());
        }
    }

    private bool TryGetRandomPositionOnNavMesh(out Vector3 randomPosition)
    {
        randomPosition = Vector3.zero;

        Vector3 position = UnityEngine.Random.insideUnitSphere * spawnRadius;
        if (NavMesh.SamplePosition(position, out NavMeshHit hit, spawnRadius, NavMesh.AllAreas))
        {
            randomPosition = hit.position;
            return true;
        }

        return false;
    }

    private string GetRandoName()
    {
        return knightNames[UnityEngine.Random.Range(0, knightNames.Length)];
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
        Handles.Label(transform.position, "Spawn Area");
    }
#endif
}
