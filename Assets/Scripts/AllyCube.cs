using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyCube : MonoBehaviour
{
    private bool isGrounded;
    private Vector3 startingPos;

    private void Start()
    {
        startingPos = transform.position;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (Vector3.Distance(startingPos, transform.position) > 1 && collision.collider.CompareTag("Ground"))
        {
            GetComponentInParent<BarsManager>().hittedAllyCubes++;
            isGrounded = true;
        }

    }
}
