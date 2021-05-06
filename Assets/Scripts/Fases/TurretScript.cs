using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    private bool canShoot = true;
    public float bulletVel = 75f;
    private bool resting;
    public Transform player;
    public GameObject bullet;
    public GameObject turretHead;
	public GameObject turretHeadHolder;
    public GameObject muzzle;

	private bool hasHeadHolder;
    //Life vars
    public int currentLife;
    public GameObject warningImage;
    private float randomTime;
	public GameObject tookDamageParticles;
	public GameObject destroyedTowerPrefab;

    void Start()
    {
        randomTime = Random.Range(2f, 5f);
		if (turretHeadHolder != null) hasHeadHolder = true;
    }


    void Update()
    {
        if (randomTime > 0)
            randomTime -= Time.deltaTime;


        if (randomTime > 0f && randomTime < 1f)
        {
            warningImage.SetActive(true);
            warningImage.transform.LookAt(player.transform);
        }else
            warningImage.SetActive(false);

        if (!resting)
        {
            var q = Quaternion.LookRotation(player.position + Vector3.up*2 - turretHead.transform.position);
			if (!hasHeadHolder)
			{
				turretHead.transform.rotation = Quaternion.RotateTowards(turretHead.transform.rotation, q, Time.deltaTime * 50f);
			}
			else
			{
				turretHeadHolder.transform.rotation = Quaternion.RotateTowards(turretHeadHolder.transform.rotation, Quaternion.Euler(turretHeadHolder.transform.rotation.x, q.eulerAngles.y, turretHeadHolder.transform.rotation.z), Time.deltaTime * 50f);
				turretHead.transform.localRotation = Quaternion.RotateTowards(turretHead.transform.localRotation, Quaternion.Euler(q.eulerAngles.x, turretHead.transform.localRotation.y, turretHead.transform.localRotation.z), Time.deltaTime * 50f);
			}
        }
        if (canShoot)
        {
            StartCoroutine(Shoot());
        }
            


        if (currentLife <= 0)
        {
            Dead();
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(randomTime);
        GameObject bulletInst = Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation);
        bulletInst.GetComponent<Rigidbody>().AddForce(turretHead.transform.forward * bulletVel, ForceMode.Impulse);
        if (GetComponent<AudioSource>())
        {
            GetComponent<AudioSource>().Play();
        }
        StartCoroutine(Rest());
    }

    IEnumerator Rest()
    {
        resting = true;
        yield return new WaitForSeconds(Random.Range(1f, 2f));
        randomTime = Random.Range(2f, 5f);
        canShoot = true;
        resting = false;

    }

    public void TakeDamage(int damageTaken)
    {

        currentLife -= damageTaken;
		Instantiate(tookDamageParticles,transform.position, Quaternion.identity, transform);
    }

    public void Dead()
    {
		Instantiate(destroyedTowerPrefab, transform.position, Quaternion.identity, null);
        Destroy(gameObject);
    }
}
