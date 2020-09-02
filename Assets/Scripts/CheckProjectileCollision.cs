using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckProjectileCollision : MonoBehaviour
{
    [HideInInspector]public Slider heroBar;
    [HideInInspector]public Slider mercenaryBar;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<EnemyCube>())
        {
            heroBar.value++;
        } else if (collision.gameObject.GetComponent<AllyCube>())
        {
            mercenaryBar.value++;
        }
    }
}
