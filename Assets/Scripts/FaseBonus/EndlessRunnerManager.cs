using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRunnerManager : MonoBehaviour
{
    public GameObject[] floors;
    public float finalZpos;
    public float initialZpos;
    public float vel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < floors.Length; i++)
        {
            floors[i].transform.position += new Vector3(0,0,-vel);
            if (floors[i].transform.position == new Vector3(0, 0, finalZpos))
            {
                floors[i].transform.position = new Vector3(0, 0, initialZpos);
            }
        }

    }
}
