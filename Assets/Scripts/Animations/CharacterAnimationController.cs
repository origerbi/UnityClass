using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    [SerializeField] private string locomotionSpeedParameter = "speed";

    private Animator animator = null;

    private string currentTrigger = "";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetLocomotionSpeed(float speed)
    {
        SetFloat(locomotionSpeedParameter, speed);
    }

    protected void SetFloat(string parameterName, float value)
    {
        animator.SetFloat(parameterName, value);
    }

    protected void SetTrigger(string trigger)
    {
        if (currentTrigger == trigger) return;

        if (currentTrigger != "") animator.ResetTrigger(currentTrigger);
        animator.SetTrigger(trigger);
        currentTrigger = trigger;
    }
}
