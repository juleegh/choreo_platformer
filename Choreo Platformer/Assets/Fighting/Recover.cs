using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recover")]
public class Recover : FightingAction
{
    [SerializeField] private int recoveredHP;

    public override void ApplyActionEffects(FighterStats executer)
    {
        executer.Heal(recoveredHP);
    }
}
