using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private static ObjectSpawner instance;

    public static ObjectSpawner Instance
    {
        get
        {
            if (instance != null)
            {
                return instance;
            }
            
            instance = new GameObject("ObjectParent").AddComponent<ObjectSpawner>();
            return instance;
        }
    }

    public GameObject Spawn(GameObject spawnedObject, Vector3 position)
    {
        return Instantiate(spawnedObject, position, Quaternion.identity, transform);
    }

    public GameObject Spawn(string objectName, Vector3 position)
    {
        GameObject newObject =  new GameObject(objectName);
        newObject.transform.parent = transform;
        newObject.transform.position = position;
        return newObject;
    }

    public void ClearObjects()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
