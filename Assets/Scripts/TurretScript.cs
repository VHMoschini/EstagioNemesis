using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    private bool canShoot = true;
    public float bulletVel = 75f;
    public Transform player;
    public GameObject bullet;
    public GameObject muzzle;
    void Start()
    {

    }


    void Update()
    {
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(player.position.x, -player.position.y, player.position.z) - transform.position, Vector3.up), 0.5f);
        transform.LookAt(player.transform);
        if(canShoot)
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        GameObject bulletInst = Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation);
        bulletInst.GetComponent<Rigidbody>().AddForce(transform.forward * bulletVel, ForceMode.Impulse);
        canShoot = true;

    }
}
