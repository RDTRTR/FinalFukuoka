using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameSystem1 : MonoBehaviour
{

	//�@�X�^�[�g�{�^�������������s����
	public void StartGame()
	{
		//Stage1��ǂݍ���
		SceneManager.LoadScene("Main");
	}

}