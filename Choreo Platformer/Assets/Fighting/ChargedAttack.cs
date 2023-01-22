using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargedAttack : FightingAction
{
    [SerializeField] private int damage;

    public override bool IsCharged(FighterStats executer)
    {
        return executer.CurrentCharge > 0;
    }

    public override void ApplyActionEffects(FighterStats executer)
    {
        if (executer.CurrentCharge > 0)
        {
            FightManager.Instance.GetOppositePlayer(executer).TakeDamage(damage);
            executer.SetCharge(0);
        }
        else
        {
            executer.SetCharge(1);
        }
    }
}
