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

    public KeyCode Up { get { return UpInput; } }
    public KeyCode Down { get { return DownInput; } }
    public KeyCode Left { get { return LeftInput; } }
    public KeyCode Right { get { return RightInput; } }
    public FightingAction UpA { get { return UpAction; } }
    public FightingAction DownA { get { return DownAction; } }
    public FightingAction LeftA { get { return LeftAction; } }
    public FightingAction RightA { get { return RightAction; } }

    [SerializeField] private FighterStats playerStats;
    private bool tempoUsed;
    private bool tempoStarted;
    private int temposNotUsed;

    void Update()
    {
        CheckForPassingTempo();

        if (!TempoCounter.Instance.IsOnTempo())
        {
            return;
        }

        FightingAction SelectedAction = null;
        if (Input.GetKeyDown(UpInput))
        {
            SelectedAction = UpAction;
        }
        /*
        else if (Input.GetKeyDown(DownInput))
        {
            SelectedAction = DownAction;
        }
        */
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
                temposNotUsed = 0;
            }
        }
    }

    private void CheckForPassingTempo()
    {
        if (!tempoStarted && TempoCounter.Instance.IsOnTempo())
        {
            tempoStarted = true;
            if (tempoUsed)
            {
                tempoUsed = false;
            }
            else
            {
                temposNotUsed++;
                if (temposNotUsed >= 1)
                {
                    playerStats.RecoverStamina();
                    temposNotUsed = 0;
                }
            }
        }

        if (tempoStarted && !TempoCounter.Instance.IsOnTempo())
        {
            tempoStarted = false;
        }
    }
}
