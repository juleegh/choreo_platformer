using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : WorldCell
{
    private void OnTriggerEnter(Collider other)
    {
        SpawnManager.Instance.UpdatePoint(this);
    }
}
