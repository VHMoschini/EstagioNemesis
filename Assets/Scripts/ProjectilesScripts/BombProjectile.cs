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
            GetComponent<MeshRenderer>().enabled = false;
			StartCoroutine(DestroyBullet(1f));
			hitted = true;
        }
    }

	private IEnumerator DestroyBullet(float tempo)
	{
		yield return new WaitForSeconds(tempo);
		if (transform.childCount > 0)
		{
			Transform child = transform.GetChild(0);
			Destroy(child.gameObject, tempo);
			child.SetParent(null);
		}
		Destroy(gameObject);
	}

}
