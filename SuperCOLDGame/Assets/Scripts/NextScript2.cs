using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NextScript : MonoBehaviour
{
	public void NextGame()
	{
		SceneManager.LoadScene("Map2", LoadSceneMode.Single);
	}
}
