using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackScript : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            audioSource.Pause();
        }
        else if (Time.timeScale == 1 && !audioSource.isPlaying)
        {
            audioSource.UnPause();

        }

    }
}
