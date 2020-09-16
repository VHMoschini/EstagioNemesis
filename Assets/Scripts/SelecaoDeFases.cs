using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelecaoDeFases : MonoBehaviour
{
	public void VaiPraFase(int numero)
	{
        SceneManager.LoadScene(numero);

    }
}
