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

    public void Setup(FighterStats fighter, KeyCode respectiveKey, string actionName)
    {
        associatedKey = respectiveKey;
        key.text = associatedKey.ToString();
        description.text = actionName;
        stats = fighter;
    }
    
    void Update()
    {
        background.color = Input.GetKey(associatedKey) ? Color.gray : Color.white;
        if (stats.CurrentCharge > 0)
        {
            background.color = Color.yellow;
        }
    }
}
