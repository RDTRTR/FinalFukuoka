using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Gamesystem : MonoBehaviour
{

	//　スタートボタンを押したら実行する
	public void StartGame()
	{
		SceneManager.LoadScene("Main");
	}

	//　ゲーム終了ボタンを押したら実行する
	public void EndGame()
	{
        #if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
        #else
		Application.Quit();
        #endif
	}


}