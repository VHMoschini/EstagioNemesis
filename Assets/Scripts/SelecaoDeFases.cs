using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelecaoDeFases : MonoBehaviour
{
    public AudioSource audioSource;

	private void Awake()
	{
		StopAllCoroutines();
		Time.timeScale = 1;
	}

	public void VaiPraFase(int numero)
    {
            SceneManager.LoadScene(numero);
    }


    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void WaitSoundCaller(int numero)
    {
        StartCoroutine(WaitSound(numero));
    }

    IEnumerator WaitSound(int numero)
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        SceneManager.LoadScene(numero);

    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
