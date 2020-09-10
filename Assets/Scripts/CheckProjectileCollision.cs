using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckProjectileCollision : MonoBehaviour
{
    public BarsManager barsManager;

	public GameObject SplashWoodParticle;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<EnemyCube>())
        {
            barsManager.hittedEnemieCubes++;

            Instantiate(SplashWoodParticle, collision.transform.position, collision.transform.rotation);
        } else if (collision.gameObject.GetComponent<AllyCube>())
        {
            barsManager.hittedAllyCubes++;
        }
    }
}
