using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckProjectileCollision : MonoBehaviour
{
    //    public BarsManager barsManager;

    public GameObject SplashWoodParticle;
	public float CameraShakeAmplitude;
	public float CameraShakeTime;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<EnemyCube>())
        {
			//barsManager.hittedEnemieCubes++;
			CameraShakeHandler.Instance.ShakeCamera(CameraShakeAmplitude, CameraShakeTime);
            Instantiate(SplashWoodParticle, collision.transform.position, collision.transform.rotation);
        }
        else if (collision.gameObject.GetComponent<TurretScript>())
        {
            collision.gameObject.GetComponent<TurretScript>().TakeDamage(3);
        }
    }
}
