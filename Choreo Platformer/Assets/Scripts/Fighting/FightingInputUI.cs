using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingInputUI : MonoBehaviour
{
    [SerializeField] private PlayerActionUI upAction;
    [SerializeField] private PlayerActionUI downAction;
    [SerializeField] private PlayerActionUI leftAction;
    [SerializeField] private PlayerActionUI rightAction;
    [SerializeField] private FightingInput relatedInput;
    [SerializeField] private FighterStats stats;

    void Start()
    {
        upAction.Setup(stats, relatedInput.Up, relatedInput.UpA.name);
        downAction.Setup(stats, relatedInput.Down, relatedInput.DownA.name);
        leftAction.Setup(stats, relatedInput.Left, relatedInput.LeftA.name);
        rightAction.Setup(stats, relatedInput.Right, relatedInput.RightA.name);
    }
}
