using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBulletScript : MonoBehaviour
{
    public int damage;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            other.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
            Destroy(gameObject, .5f);
        }
    }
}
