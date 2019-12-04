using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NextScript2 : MonoBehaviour
{
	public void NextGame2()
	{
		SceneManager.LoadScene("Map3", LoadSceneMode.Single);
	}
}
