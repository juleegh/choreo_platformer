using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get { return instance; } }
    private static SpawnManager instance;
    [SerializeField] private DanceCharacter character;
    [SerializeField] private SpawnPoint initialPoint;
    private SpawnPoint current;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        current = initialPoint;
    }

    public void Respawn()
    {
        character.transform.position = current.transform.position;
        character.GetComponent<HealthSystem>().Restart();
    }

    public void UpdatePoint(SpawnPoint newPoint)
    {
        current = newPoint;
    }
}
