using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string Tag;
        public GameObject Prefab;
        public int Size;
    }

    public List<Pool> Pools;
    public Dictionary<string, Queue<GameObject>> PoolDictionary;
    void Start()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();
        AllocatePools();
    }
    void AllocatePools()
    {
        foreach (var pool in Pools)
        {
            var objectPool = new Queue<GameObject>();

            for (var i = 0; i < pool.Size; i++)
            {
                var obj = Instantiate(pool.Prefab, gameObject.transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            PoolDictionary.Add(pool.Tag, objectPool);
        }
    }
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!PoolDictionary.ContainsKey(tag))
        {
            Debug.LogException(new System.Exception("Tag \"" + tag + "\" missing from PoolDictionary"));
        }

        GameObject objectToSpawn = PoolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        var pooledObject = objectToSpawn.GetComponent<IPooledObject>();

        if (pooledObject != null)
        {
            pooledObject.OnObjectSpawn();
        }

        PoolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
