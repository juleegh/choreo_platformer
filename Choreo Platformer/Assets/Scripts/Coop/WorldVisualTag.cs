using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldVisualTag : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sign;
    private TagHolder tagOwner;
    // Start is called before the first frame update
    void Start()
    {
        tagOwner = transform.parent.GetComponent<TagHolder>();
        transform.localPosition = new Vector3(0, 2f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = Vector3.zero;
        sign.text = tagOwner.GetTagContent();
    }
}

public interface TagHolder
{
    public string GetTagContent();
}
