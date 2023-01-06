using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class KnightController : MonoBehaviour
{
    [SerializeField] private string knightName = "Knight";

    [Header("Components")]
    [SerializeField] private NpcNameTag npcNameTag = null;

    [Header("Sword Settings")]
    [SerializeField] private Transform sword = null;
    [SerializeField] private Transform swordHandHolder = null;
    [SerializeField] private Transform swordSheathHolder = null;

    [Header("Detection Settings")]
    [SerializeField] private float detectionRange = 5f;

    [Header("Patrol Settings")]
    [SerializeField] private float maxTravelDistance = 1f;

    private NpcMovement npcMovement = null;
    private KnightAnimationController knightAnimationController = null;

    private PlayerMovement playerMovement = null;

    private void OnValidate()
    {
        if (npcNameTag) npcNameTag.SetName(knightName);
    }

    private void Awake()
    {
        npcMovement = GetComponent<NpcMovement>();
        knightAnimationController = GetComponent<KnightAnimationController>();

        playerMovement = FindObjectOfType<PlayerMovement>();

        if (!swordHandHolder)
        {
            // find the nested child object the name
        }
    }

    private void Update()
    {
        npcNameTag.Toggle(IsPlayerDetected());

        if (playerMovement && OnPlayerDetected()) return;

        if (!npcMovement.HasPath())
        {
            MoveToNewPoint();
            return;
        }
    }

    public void SetName(string newName)
    {
        knightName = newName;
        npcNameTag.SetName(knightName);
    }

    private bool OnPlayerDetected()
    {
        if (IsPlayerDetected())
        {
            HandlePlayerDetected();
            return true;
        }

        npcMovement.Resume();
        knightAnimationController.TriggerSheathSword();
        return false;
    }

    private bool IsPlayerDetected()
    {
        return Vector3.Distance(transform.position, playerMovement.transform.position) <= detectionRange;
    }

    private void HandlePlayerDetected()
    {
        npcMovement.Pause();

        Vector3 playerDirection = playerMovement.transform.position - transform.position;
        // Set y to 0 so that the knight doesn't look up or down at the player
        playerDirection.y = 0f;
        Quaternion playerLookRotation = Quaternion.LookRotation(playerDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, playerLookRotation, Time.deltaTime * 5f);

        knightAnimationController.TriggerWidthrawSword();
    }

    private void MoveToNewPoint()
    {
        Vector3 randomPoint = npcMovement.GetRandomPointOnNavMesh(maxTravelDistance);
        npcMovement.MoveTo(randomPoint);
    }

    // Called in animation event
    private void WidthrawSword()
    {
        sword.SetParent(swordHandHolder);
        sword.localPosition = Vector3.zero;
        sword.localRotation = Quaternion.identity;
    }

    // Called in animation event
    private void SheathSword()
    {
        sword.SetParent(swordSheathHolder);
        sword.localPosition = Vector3.zero;
        sword.localRotation = Quaternion.identity;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxTravelDistance);
        Handles.Label(transform.position, "Travel Range");

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Handles.Label(transform.position, "Detection Range");
    }
#endif
}
