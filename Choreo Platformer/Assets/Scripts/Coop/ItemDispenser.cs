using UnityEngine;
using System.Collections.Generic;

public class ItemDispenser : MonoBehaviour
{
    private static ItemDispenser instance;
    public  static ItemDispenser Instance {  get { return instance; } }

    private void Awake()
    {
        instance = this;    
    }

    public GameObject prefab;
    private Stack<GameObject> inactiveInstances = new Stack<GameObject>();

    public TaskItem GetObject(TaskItemType itemType)
    {
        GameObject spawnedGameObject;
        TaskItem taskItem;

        if (inactiveInstances.Count > 0)
        {
            spawnedGameObject = inactiveInstances.Pop();
        }
        else
        {
            spawnedGameObject = (GameObject) GameObject.Instantiate(prefab);

            PooledObject pooledObject = spawnedGameObject.AddComponent<PooledObject>();
            pooledObject.pool = this;
        }

        spawnedGameObject.transform.SetParent(null);
        spawnedGameObject.SetActive(true);

        taskItem = spawnedGameObject.GetComponent<TaskItem>();
        taskItem.Reset(itemType);

        return taskItem;
    }

    public void ReturnObject(GameObject toReturn)
    {
        PooledObject pooledObject = toReturn.GetComponent<PooledObject>();

        if (pooledObject != null && pooledObject.pool == this)
        {
            toReturn.transform.SetParent(transform);
            toReturn.SetActive(false);

            inactiveInstances.Push(toReturn);
        }
    }
}

public class PooledObject : MonoBehaviour
{
    public ItemDispenser pool;
}