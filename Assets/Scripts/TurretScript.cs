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
    public GameObject muzzle;
    //Life vars
    public int currentLife;


    void Start()
    {

    }


    void Update()
    {

        if (!resting)
        {
            var q = Quaternion.LookRotation(player.position - turretHead.transform.position);
            turretHead.transform.rotation = Quaternion.RotateTowards(turretHead.transform.rotation, q, Time.deltaTime * 50f);
        }
        if (canShoot)
        {
            StartCoroutine(Shoot());

        }

        if(currentLife <= 0)
        {
            Dead();
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        GameObject bulletInst = Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation);
        bulletInst.GetComponent<Rigidbody>().AddForce(turretHead.transform.forward * bulletVel, ForceMode.Impulse);
        StartCoroutine(Rest());
    }

    IEnumerator Rest()
    {
        resting = true;
        yield return new WaitForSeconds(Random.Range(1f, 2f));
        canShoot = true;
        resting = false;

    }

    public void TakeDamage(int damageTaken)
    {
        Debug.Log("ai");
        currentLife -= damageTaken;
    }

    public void Dead()
    {
        Destroy(gameObject);
    }
}
