using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultProjectile : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 1f);
    }
}
