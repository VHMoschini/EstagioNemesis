using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombProjectile : MonoBehaviour
{
    public ParticleSystem explosionEffects;
    private bool hitted;
	public float CameraShakeAmplitude;
	public float CameraShakeTime;


	private void OnCollisionEnter(Collision collision)
    {
        if (!hitted)
        {
            Instantiate(explosionEffects, transform.position, transform.rotation);
			CameraShakeHandler.Instance.ShakeCamera(CameraShakeAmplitude, CameraShakeTime);
			GetComponent<SphereCollider>().enabled = true;
            Destroy(gameObject, 0.1f);
            hitted = true;
        }
    }



}
