using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLaserCollision : MonoBehaviour
{
    public BarsManager barsManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<EnemyCube>())
        {
            barsManager.hittedEnemieCubes++;
        }
        else if (collision.gameObject.GetComponent<AllyCube>())
        {
            barsManager.hittedAllyCubes++;
        }
    }
}
