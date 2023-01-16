using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NormalAttack")]
public class NormalAttack : FightingAction
{
    [SerializeField] private int damage;

    public override void ApplyActionEffects(FighterStats executer)
    {
        FightManager.Instance.GetOppositePlayer(executer).TakeDamage(damage);
    }
}
