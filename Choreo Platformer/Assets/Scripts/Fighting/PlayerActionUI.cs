using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerActionUI : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private TextMeshProUGUI key;
    [SerializeField] private TextMeshProUGUI description;
    private KeyCode associatedKey;
    private FighterStats stats;
    private FightingAction associatedAction;

    public void Setup(FighterStats fighter, KeyCode respectiveKey, FightingAction actionName)
    {
        associatedKey = respectiveKey;
        key.text = associatedKey.ToString();
        associatedAction = actionName;
        description.text = actionName.name;
        stats = fighter;
    }
    
    void Update()
    {
        background.color = Input.GetKey(associatedKey) ? Color.gray : Color.white;
        if (associatedAction.IsCharged(stats))
        {
            background.color = Color.yellow;
        }
    }
}
