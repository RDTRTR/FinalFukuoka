using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GamesystemT : MonoBehaviour
{

	//　スタートボタンを押したら実行する
	public void StartGame()
	{
		//実行したら三秒後にシーン遷移
		Invoke("Stageselect", 3);
		SceneManager.LoadScene("Stageselect");

	}

	//void LoadStageselect()
	//{
	//	SceneManager.LoadScene("Stageselect");
	//}

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