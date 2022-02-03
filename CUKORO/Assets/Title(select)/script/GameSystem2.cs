using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameSystem2 : MonoBehaviour
{

	//　スタートボタンを押したら実行する
	public void StartGame()
	{
		//Stage2を読み込む
		SceneManager.LoadScene("Stage2");
	}

}