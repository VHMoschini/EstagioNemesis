using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelecaoDeFases : MonoBehaviour
{
	public void VaiPraFase(int numero)
	{
		switch (numero)
		{
			case 1:
				SceneManager.LoadScene("Mapa1");
				break;

			case 2:
				SceneManager.LoadScene("Mapa2");
				break;

			case 3:
				SceneManager.LoadScene("Mapa3");
				break;

			default:
				SceneManager.LoadScene(0);
				break;
		}
		

	}
}
