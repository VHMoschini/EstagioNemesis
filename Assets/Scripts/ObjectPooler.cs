using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ObjectPooler : MonoBehaviour
{
    // Start is called before the first frame update

    public PoolObject[] poolObjects;



    void Start()
    {
        CreateObjects();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void CreateObjects()
    {
        for (int i = 0; i < poolObjects.Length; i++)
        {
            for (int j = 0; j < poolObjects[i].amountToPool; j++)
            {
                GameObject ObjInst = Instantiate(poolObjects[i].objecToPool);
                ObjInst.gameObject.SetActive(false);
                FillList(ObjInst, i);
            }
        }
    }

    private void FillList(GameObject _pooledObject, int listIndex)
    {
        poolObjects[listIndex].pool.Add(_pooledObject);
    }
}


[Serializable]
public class PoolObject
{
    public GameObject objecToPool;
    public int amountToPool;
    public List<GameObject> pool = new List<GameObject>();


}
