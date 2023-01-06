using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAnimationController : CharacterAnimationController
{
    [SerializeField] private string widthrawSwordTrigger = "widthrawSword";
    [SerializeField] private string sheathSwordTrigger = "sheathSword";

    public void TriggerWidthrawSword()
    {
        SetTrigger(widthrawSwordTrigger);
    }

    public void TriggerSheathSword()
    {
        SetTrigger(sheathSwordTrigger);
    }
}
