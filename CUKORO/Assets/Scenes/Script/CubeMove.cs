using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum panelsetcolor
{
	Red,
	Blue,
	Green,
	White,
};

public class CubeMove : MonoBehaviour
{

	//染める色を決定する
	public panelsetcolor winnercolor;

	//判定関数
	private bool Colorgudge()
	{

		//現在のパネルの色を調べる
		panelsetcolor checkcolor;

		checkcolor = panelObject[0].GetComponent<ChangeColor>().mycolor;

		Debug.Log("call" + checkcolor);

		//すべての面を調べ、違うならfalseを返す
		for (int i = 0; i < 6; i++)
		{
			if (checkcolor != panelObject[i].GetComponent<ChangeColor>().mycolor)
			{
				return false;
			}
		}

		//そろっていたらtrueを返す
		if (checkcolor == winnercolor)
		{
			return true;
		}

		return false;

	}

	Vector3 rotatePoint = Vector3.zero;  //回転の中心
	Vector3 rotateAxis = Vector3.zero;   //回転軸
	float cubeAngle = 0f;                //回転角度

	public GameObject[] panelObject;     //配列に自分はどのパネルなのかを入れる
    ChangeColor[] colorcs = new ChangeColor[6]; //配列に要素を代入
	float cubeSizeHalf;                  //キューブの大きさの半分
	bool isRotate = false;               //回転中に立つフラグ。回転中は入力を受け付けない
	bool latestisRotate = false;         //回転しているかしていないかのフラグ

	public GameObject clearCanvas; //クリア表示キャンバス
	public GameObject playSound; //SE
	public bool gameEnd = false; //ゲーム終了フラグ

	public int count; //残りカウント

	public Text countText; //カウントのテキスト

	public GameObject cameraObject;
	CameraRotate cameraAngle;

	void Start()
	{
		count = 0; //カウントを初期化

		cubeSizeHalf = transform.localScale.x / 2f;

		//6回回してそれぞれにパネルの色を覚えさせる
		for(int i = 0; i < 6; i++)
        {
			//Debug.Log("A" + i);
			colorcs[i] = panelObject[i].GetComponent<ChangeColor>();
		}

		countText.text = "6"; //残りの染めないといけない面の数

		cameraAngle = cameraObject.GetComponent<CameraRotate>();

	}


	void Update()
	{

		//Debug.Log(cameraAngle.nowAngle);

		count = 0; //フレームごとに初期化

		//すべての面を見てあっていない面の数を見る
		for (int i = 0; i < 6; i++)
		{
			if (colorcs[i].mycolor != winnercolor)
			{
				count++;
			}

		}

		countText.text = count.ToString(); //残りの数を表示する

		//回転中は入力を受け付けない
		if (isRotate)
		{
			latestisRotate = true;

			return;
		}

		//回転が終わっていたら入る
		if (latestisRotate)
		{
			if (Colorgudge())
			{
				Debug.Log("win");

				//canvasに送る
				clearCanvas.SendMessage("OnEnter");

				//playSoundに送る
				playSound.SendMessage("OnEnter");

				gameEnd = true;
			}

			

			latestisRotate = false;
		}



		//ゲームが終わったら操作できなくなるようにする
		if (!gameEnd)
		{

			if(cameraAngle.nowAngle == 0.0f)
            {
				//プレイヤー移動処理
				//右
				if (Input.GetKeyDown(KeyCode.RightArrow))
				{

					rotatePoint = transform.position + new Vector3(cubeSizeHalf, -cubeSizeHalf, 0f);
					rotateAxis = new Vector3(0, 0, -1);
				}

				//左
				if (Input.GetKeyDown(KeyCode.LeftArrow))
				{

					rotatePoint = transform.position + new Vector3(-cubeSizeHalf, -cubeSizeHalf, 0f);
					rotateAxis = new Vector3(0, 0, 1);

				}

				//上
				if (Input.GetKeyDown(KeyCode.UpArrow))
				{
					rotatePoint = transform.position + new Vector3(0f, -cubeSizeHalf, cubeSizeHalf);
					rotateAxis = new Vector3(1, 0, 0);
				}

				//下
				if (Input.GetKeyDown(KeyCode.DownArrow))
				{
					rotatePoint = transform.position + new Vector3(0f, -cubeSizeHalf, -cubeSizeHalf);
					rotateAxis = new Vector3(-1, 0, 0);
				}

				// 入力がない時はコルーチンを呼び出さないようにする
				if (rotatePoint == Vector3.zero)
					return;

				StartCoroutine(MoveCube());


			}

			if (cameraAngle.nowAngle == 180)
            {
				//プレイヤー移動処理
				//右
				if (Input.GetKeyDown(KeyCode.RightArrow))
				{

					rotatePoint = transform.position + new Vector3(-cubeSizeHalf, -cubeSizeHalf, 0f);
					rotateAxis = new Vector3(0, 0, 1);
				}

				//左
				if (Input.GetKeyDown(KeyCode.LeftArrow))
				{

					rotatePoint = transform.position + new Vector3(cubeSizeHalf, -cubeSizeHalf, 0f);
					rotateAxis = new Vector3(0, 0, -1);

				}

				//上
				if (Input.GetKeyDown(KeyCode.UpArrow))
				{
					rotatePoint = transform.position + new Vector3(0f, -cubeSizeHalf, -cubeSizeHalf);
					rotateAxis = new Vector3(-1, 0, 0);
				}

				//下
				if (Input.GetKeyDown(KeyCode.DownArrow))
				{
					rotatePoint = transform.position + new Vector3(0f, -cubeSizeHalf, cubeSizeHalf);
					rotateAxis = new Vector3(1, 0, 0);
				}

				// 入力がない時はコルーチンを呼び出さないようにする
				if (rotatePoint == Vector3.zero)
					return;

				StartCoroutine(MoveCube());
			}

		}

	}


	IEnumerator MoveCube()
	{
		//回転中のフラグを立てる
		isRotate = true;

		//回転処理
		float sumAngle = 0f; //angleの合計を保存
		while (sumAngle < 90f)
		{
			cubeAngle = 5.0f; //ここを変えると回転速度が変わる
			sumAngle += cubeAngle;

			// 90度以上回転しないように値を制限
			if (sumAngle > 90f)
			{
				cubeAngle -= sumAngle - 90f;
			}
			transform.RotateAround(rotatePoint, rotateAxis, cubeAngle);

			yield return null;
		}

		//回転中のフラグを倒す
		isRotate = false;
		Debug.Log("isRotate false");
		rotatePoint = Vector3.zero;
		rotateAxis = Vector3.zero;

		yield break;
	}

}