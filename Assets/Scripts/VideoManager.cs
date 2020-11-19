using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
	private VideoPlayer m_VideoPlayer;

	void Awake()
	{
		m_VideoPlayer = GetComponent<VideoPlayer>();
		m_VideoPlayer.loopPointReached += OnMovieFinished;
	}

	void OnMovieFinished(VideoPlayer player)
	{
		player.Stop();
		SceneManager.LoadScene(1);
		Destroy(gameObject);
		
	}
}
