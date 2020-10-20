using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleForceFieldPositioner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		transform.position = Camera.main.ScreenToWorldPoint(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
