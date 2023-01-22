using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingAction : ScriptableObject
{
    public virtual bool IsCharged(FighterStats executer)
    {
        return false;
    }
    
    public virtual void ApplyActionEffects(FighterStats executer)
    { 
        // Depends on the action
    }
}
