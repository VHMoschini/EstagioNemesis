using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBulletScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
            Destroy(gameObject);
    }
}
