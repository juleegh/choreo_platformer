using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingInput : MonoBehaviour
{
    [SerializeField] private KeyCode UpInput;
    [SerializeField] private KeyCode DownInput;
    [SerializeField] private KeyCode LeftInput;
    [SerializeField] private KeyCode RightInput;
    [SerializeField] private FightingAction UpAction;
    [SerializeField] private FightingAction DownAction;
    [SerializeField] private FightingAction LeftAction;
    [SerializeField] private FightingAction RightAction;
    [SerializeField] private FighterStats playerStats;
    private bool tempoUsed;

    void Update()
    {
        if (tempoUsed)
        {
            if (!TempoCounter.Instance.IsOnTempo())
            {
                tempoUsed = false;
            }
        }
        
        if (!TempoCounter.Instance.IsOnTempo())
        {
            return;
        }

        FightingAction SelectedAction = null;
        if (Input.GetKeyDown(UpInput))
        {
            SelectedAction = UpAction;
        }
        else if (Input.GetKeyDown(DownInput))
        {
            SelectedAction = DownAction;
        }
        else if (Input.GetKeyDown(LeftInput))
        {
            SelectedAction = LeftAction;
        }
        else if (Input.GetKeyDown(RightInput))
        {
            SelectedAction = RightAction;
        }

        if (SelectedAction != null)
        {
            bool performedAction = playerStats.TryUseStamina();
            if (performedAction)
            {
                SelectedAction.ApplyActionEffects(playerStats);
                tempoUsed = true;
            }
        }
    }
}
