using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public static FightManager Instance { get { return instance; } }
    private static FightManager instance;
    [SerializeField] private FighterStats player1;
    [SerializeField] private FighterStats player2;

    private void Awake()
    {
        instance = this;
    }

    public FighterStats GetOppositePlayer(FighterStats executer)
    {
        if (executer == player1)
        {
            return player2;
        }
        return player1;
    }
}
