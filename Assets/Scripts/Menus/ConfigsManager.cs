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

    float valueSfx;
    bool resultSfx;
    float valueMusic;
    bool resultMusic;


    void Start()
    {
        generalSoundSlider.value = AudioListener.volume;
        GetSfxVolume();
        GetSoundVolume();
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = generalSoundSlider.value;
        sfx.SetFloat("VolumeMaster(SFX)", sfxSlider.value);
        music.SetFloat("VolumeSounds", musicSlider.value);

    }

    private void GetSfxVolume()
    {
        resultSfx = sfx.GetFloat("VolumeMaster(SFX)", out valueSfx);
        if (resultSfx)
        {
            sfxSlider.value = valueSfx;
        }
    }

    private void GetSoundVolume()
    {
        resultMusic = music.GetFloat("VolumeSounds", out valueMusic);
        if (resultMusic)
        {
            musicSlider.value = valueMusic;
        }
    }
}
