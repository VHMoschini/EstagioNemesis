using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxX = 16;
    private float actualPosX;
    private float randomTimeToChangePos;
    public int posVariation = 1;


    void Start()
    {
        randomTimeToChangePos = Random.Range(0.1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        randomTimeToChangePos -= Time.deltaTime;
        if(randomTimeToChangePos <= 0)
        {
            ChangePos();
            randomTimeToChangePos = Random.Range(1f, 3f);
        }
        actualPosX = transform.position.x;

    }


    public void ChangePos()
    {
        float random = Random.value;
        float deltaPos = 0f;
        if (random > 0.5f)
        {
            deltaPos = posVariation;
        }
        else if (random < 0.5f)
        {
            deltaPos = -posVariation;
        }else if (transform.position.x == 16)
        {
            deltaPos = -posVariation;

        }else if (transform.position.x == -16)
        {
            deltaPos = posVariation;

        }

        transform.position = new Vector3(actualPosX + deltaPos, transform.position.y, transform.position.z); 
    }
}
