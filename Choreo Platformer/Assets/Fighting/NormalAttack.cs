using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttack : FightingAction
{
    [SerializeField] private int damage;

    public override void ApplyActionEffects(FighterStats executer)
    {
        FightManager.Instance.GetOppositePlayer(executer).TakeDamage(damage);
    }
}
