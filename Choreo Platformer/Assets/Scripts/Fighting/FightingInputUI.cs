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
    
    void Start()
    {
        upAction.Setup(relatedInput.Up, relatedInput.UpA.name);
        downAction.Setup(relatedInput.Down, relatedInput.DownA.name);
        leftAction.Setup(relatedInput.Left, relatedInput.LeftA.name);
        rightAction.Setup(relatedInput.Right, relatedInput.RightA.name);
    }
}
