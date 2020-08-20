using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
	public Transform player;
    
    void Start()
    {
        
    }

    
    void Update()
    {
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(player.position.x, -player.position.y, player.position.z) - transform.position, Vector3.up), 0.5f);
    }
}
