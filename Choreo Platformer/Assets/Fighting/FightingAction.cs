using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FightingAction")]
public class FightingAction : ScriptableObject
{
    public virtual void ApplyActionEffects(FighterStats executer)
    { 
        // Depends on the action
    }
}
