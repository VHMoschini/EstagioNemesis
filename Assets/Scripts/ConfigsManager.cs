using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ConfigsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider generalSoundSlider;
    public Slider sfxSlider;
    public Slider musicSlider;

    public AudioMixer sfx;
    public AudioMixer music;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = generalSoundSlider.value;
        sfx.SetFloat("VolumeMaster(SFX)", sfxSlider.value);
        music.SetFloat("VolumeSounds", musicSlider.value);

    }
}
