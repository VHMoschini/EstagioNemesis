using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
	private VideoPlayer m_VideoPlayer;
    public GameObject menu;


	private void Awake()
	{
		m_VideoPlayer = GetComponent<VideoPlayer>();
		m_VideoPlayer.loopPointReached += OnMovieFinished;
	}

	private void OnMovieFinished(VideoPlayer player)
	{
		player.Stop();
		menu.SetActive(true);
		Destroy(gameObject);
	}

	public void StopFilm()
	{
		OnMovieFinished(m_VideoPlayer);
	}
}
