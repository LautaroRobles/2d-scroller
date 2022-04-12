using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ObjectPool/Multiple")]
public class MultiObjectPoolSO : ScriptableObject
{
    public List<GameObject> Prefabs;
    public int PoolSize;
    private Queue<GameObject> _pool;
    private Transform _parent;
    public void SpawnPool()
    {
        if (_pool == null || _pool.Count == 0)
        {
            _pool = new Queue<GameObject>();
        }

        if (_pool.Count >= PoolSize)
        {
            return;
        }

        if (_parent == null)
        {
            _parent = new GameObject(name).transform;
        }

        while (_pool.Count < PoolSize)
        {
            for (int i = 0; i < Prefabs.Count; i++)
            {
                GameObject gameObject = Instantiate(Prefabs[i], _parent);
                gameObject.SetActive(false);
                _pool.Enqueue(gameObject);
            }
        }
    }
    public GameObject SpawnObject(Vector3 position, Quaternion rotation)
    {
        if (_pool == null || _pool.Count == 0)
        {
            SpawnPool();
        }

        GameObject gameObject = _pool.Dequeue();
        gameObject.SetActive(false);
        gameObject.transform.position = position;
        gameObject.transform.rotation = rotation;
        gameObject.SetActive(true);
        _pool.Enqueue(gameObject);
        return gameObject;
    }
}
