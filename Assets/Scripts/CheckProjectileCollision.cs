using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckProjectileCollision : MonoBehaviour
{
    [HideInInspector]public Slider heroBar;
    [HideInInspector]public Slider mercenaryBar;

	public GameObject SplashWoodParticle;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<EnemyCube>())
        {
            heroBar.value++;
			Instantiate(SplashWoodParticle, collision.transform.position, collision.transform.rotation);
        } else if (collision.gameObject.GetComponent<AllyCube>())
        {
            mercenaryBar.value++;
        }
    }
}
