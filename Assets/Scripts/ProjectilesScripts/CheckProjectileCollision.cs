using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckProjectileCollision : MonoBehaviour
{
    //    public BarsManager barsManager;

    public GameObject SplashWoodParticle;
	public float CameraShakeAmplitude;
	public float CameraShakeTime;
    public int damageToDo = 3;

    private void OnCollisionEnter(Collision collision)
    {
        if (GetComponent<AudioSource>() && !GetComponent<AudioSource>().isPlaying)
        {
            Debug.Log("tocou");
            GetComponent<AudioSource>().Play();
        }
        if (collision.gameObject.GetComponent<EnemyCube>())
        {
			//barsManager.hittedEnemieCubes++;
			CameraShakeHandler.Instance.ShakeCamera(CameraShakeAmplitude, CameraShakeTime);
            Instantiate(SplashWoodParticle, collision.transform.position, collision.transform.rotation);
        }
        else if (collision.gameObject.GetComponent<TurretScript>())
        {
            collision.gameObject.GetComponent<TurretScript>().TakeDamage(damageToDo);
			CameraShakeHandler.Instance.ShakeCamera(CameraShakeAmplitude, CameraShakeTime);
		}
        else if (collision.gameObject.GetComponent<EnemyAttack>())
        {
            collision.gameObject.GetComponent<EnemyAttack>().TakeDamage(damageToDo);
			CameraShakeHandler.Instance.ShakeCamera(CameraShakeAmplitude, CameraShakeTime);
		}
    }
}
