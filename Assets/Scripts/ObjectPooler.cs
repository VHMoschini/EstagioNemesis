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
        FillList();
        CreateObjects();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void FillList()
    {
        for (int i = 0; i < poolObjects.Length; i++)
        {
            for (int j = 0; j < poolObjects[i].amountToPool; j++)
            {
                poolObjects[i].pool.Add(poolObjects[i].objecToPool);
            }
        }
    }

    private void CreateObjects()
    {
        for (int i = 0; i < poolObjects.Length; i++)
        {
            for (int j = 0; j < poolObjects[i].amountToPool; j++)
            {
                GameObject ObjInst = Instantiate(poolObjects[i].objecToPool);
                ObjInst.gameObject.SetActive(false);
            }
        }
    }

    private void AddToList(int listIndex, GameObject objectInList)
    {

    }
}


[Serializable]
public class PoolObject
{
    public GameObject objecToPool;
    public int amountToPool;
    [HideInInspector]
    public List<GameObject> pool = new List<GameObject>();


}
