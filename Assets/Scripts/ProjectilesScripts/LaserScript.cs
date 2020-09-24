using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LaserScript : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> lasers = new List<GameObject>();
	public float CameraShakeAmplitude;
	public float CameraShakeTime;
	void Start()
    {
        for (int i = 0; i < lasers.Count; i++)
        {
            lasers[i].transform.DOScaleY(40, .8f);
            lasers[1].transform.DORotate(new Vector3(Random.Range(-30,30), 0 , Random.Range(-30, 30)), .5f);
            lasers[2].transform.DORotate(new Vector3(Random.Range(-30, 30), 0, Random.Range(-30, 30)), .5f);

        }
		CameraShakeHandler.Instance.ShakeCamera(CameraShakeAmplitude, CameraShakeTime);
		Destroy(gameObject, 1f);
    }

}
