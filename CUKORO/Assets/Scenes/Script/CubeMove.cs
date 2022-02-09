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

	//���߂�F�����肷��
	public panelsetcolor winnercolor;

	//����֐�
	private bool Colorgudge()
	{

		//���݂̃p�l���̐F�𒲂ׂ�
		panelsetcolor checkcolor;

		checkcolor = panelObject[0].GetComponent<ChangeColor>().mycolor;

		//Debug.Log("call" + checkcolor);

		//���ׂĂ̖ʂ𒲂ׁA�Ⴄ�Ȃ�false��Ԃ�
		for (int i = 0; i < 6; i++)
		{
			if (checkcolor != panelObject[i].GetComponent<ChangeColor>().mycolor)
			{
				return false;
			}
		}

		//������Ă�����true��Ԃ�
		if (checkcolor == winnercolor)
		{
			return true;
		}

		return false;

	}

	Vector3 rotatePoint = Vector3.zero;  //��]�̒��S
	Vector3 rotateAxis = Vector3.zero;   //��]��
	float cubeAngle = 0f;                //��]�p�x

	public GameObject[] panelObject;     //�z��Ɏ����͂ǂ̃p�l���Ȃ̂�������
    ChangeColor[] colorcs = new ChangeColor[6]; //�z��ɗv�f����
	float cubeSizeHalf;                  //�L���[�u�̑傫���̔���
	bool isRotate = false;               //��]���ɗ��t���O�B��]���͓��͂��󂯕t���Ȃ�
	bool latestisRotate = false;         //��]���Ă��邩���Ă��Ȃ����̃t���O

	public GameObject clearCanvas; �@�@�@//�N���A�\���L�����o�X
	public GameObject playSound; �@�@�@�@//SE
	bool gameEnd = false; �@�@�@�@       //�Q�[���I���t���O

	private int count; �@�@�@�@�@�@�@�@�@//�c��J�E���g

	public Text countText;               //�J�E���g�̃e�L�X�g

	public GameObject cameraObject; �@�@ //�J�����I�u�W�F�N�g
	CameraRotate cameraRotate;

	void Start()
	{
		count = 0; //�J�E���g��������

		cubeSizeHalf = transform.localScale.x / 2f;

		//6��񂵂Ă��ꂼ��Ƀp�l���̐F���o��������
		for(int i = 0; i < 6; i++)
        {
			//Debug.Log("A" + i);
			colorcs[i] = panelObject[i].GetComponent<ChangeColor>(); //ChangeColor��CS���
		}

		countText.text = "6"; //�c��̐��߂Ȃ��Ƃ����Ȃ��ʂ̐�

		cameraRotate = cameraObject.GetComponent<CameraRotate>(); //CameraRotate��CS���
	}


	void Update()
	{

		count = 0; //�t���[�����Ƃɏ�����

		//��]���I����Ă��������
		if (latestisRotate)
		{
			//�F����Ăяo��
			if (Colorgudge())
			{

				cameraRotate.rotateFlag = true;

				gameEnd = true;

				//canvas�ɑ���
				clearCanvas.SendMessage("OnEnter");

				//playSound�ɑ���
				playSound.SendMessage("OnEnter");

				//Debug.Log("win");

			}

			latestisRotate = false;
		}

		//���ׂĂ̖ʂ����Ă����Ă��Ȃ��ʂ̐�������
		for (int i = 0; i < 6; i++)
		{
			if (colorcs[i].mycolor != winnercolor)
			{
				count++;
			}
		}

		//�c��̐���\������
		countText.text = count.ToString(); 

		//��]���͓��͂��󂯕t���Ȃ�
		if (isRotate)
		{
			latestisRotate = true;

			return;
		}

		//�Q�[�����I������瑀��ł��Ȃ��Ȃ�悤�ɂ���
		if (!gameEnd && !cameraRotate.rotateFlag)
		{
			//�J�����̈ړ����̓v���C���[�̑�����ł��Ȃ��Ȃ�悤�ɂ���
			//�J��������
			if(cameraRotate.count == 0 && cameraRotate.rotateFlag == false)
            {
				//�v���C���[�ړ�����
				//�E
				if (Input.GetKeyDown(KeyCode.RightArrow))
				{
					rotatePoint = transform.position + new Vector3(cubeSizeHalf, -cubeSizeHalf, 0f);
					rotateAxis = new Vector3(0, 0, -1);
				}

				//��
				if (Input.GetKeyDown(KeyCode.LeftArrow))
				{
					rotatePoint = transform.position + new Vector3(-cubeSizeHalf, -cubeSizeHalf, 0f);
					rotateAxis = new Vector3(0, 0, 1);
				}

				//��
				if (Input.GetKeyDown(KeyCode.UpArrow))
				{
					rotatePoint = transform.position + new Vector3(0f, -cubeSizeHalf, cubeSizeHalf);
					rotateAxis = new Vector3(1, 0, 0);
				}

				//��
				if (Input.GetKeyDown(KeyCode.DownArrow))
				{
					rotatePoint = transform.position + new Vector3(0f, -cubeSizeHalf, -cubeSizeHalf);
					rotateAxis = new Vector3(-1, 0, 0);
				}

				// ���͂��Ȃ����̓R���[�`�����Ăяo���Ȃ��悤�ɂ���
				if (rotatePoint == Vector3.zero)
					return;

				StartCoroutine(MoveCube());
			}
			//�J������
			else if((cameraRotate.count == 1 || cameraRotate.count == -3) && cameraRotate.rotateFlag == false)
            {
				//�v���C���[�ړ�����
				//�E
				if (Input.GetKeyDown(KeyCode.RightArrow))
				{
					rotatePoint = transform.position + new Vector3(0f, -cubeSizeHalf, -cubeSizeHalf);
					rotateAxis = new Vector3(-1, 0, 0);
				}

				//��
				if (Input.GetKeyDown(KeyCode.LeftArrow))
				{
					rotatePoint = transform.position + new Vector3(0f, -cubeSizeHalf, cubeSizeHalf);
					rotateAxis = new Vector3(1, 0, 0);
				}

				//��
				if (Input.GetKeyDown(KeyCode.UpArrow))
				{
					rotatePoint = transform.position + new Vector3(cubeSizeHalf, -cubeSizeHalf, 0f);
					rotateAxis = new Vector3(0, 0,-1);
				}

				//��
				if (Input.GetKeyDown(KeyCode.DownArrow))
				{
					rotatePoint = transform.position + new Vector3(-cubeSizeHalf, -cubeSizeHalf,0f);
					rotateAxis = new Vector3(0, 0, 1);
				}

				// ���͂��Ȃ����̓R���[�`�����Ăяo���Ȃ��悤�ɂ���
				if (rotatePoint == Vector3.zero)
					return;

				StartCoroutine(MoveCube());
			}
			//�J�����E
			else if ((cameraRotate.count == 3 || cameraRotate.count == -1) && cameraRotate.rotateFlag == false)
			{
				//�v���C���[�ړ�����
				//�E
				if (Input.GetKeyDown(KeyCode.RightArrow))
				{
					rotatePoint = transform.position + new Vector3(0f, -cubeSizeHalf, cubeSizeHalf);
					rotateAxis = new Vector3(1, 0, 0);
				}

				//��
				if (Input.GetKeyDown(KeyCode.LeftArrow))
				{
					rotatePoint = transform.position + new Vector3(0f, -cubeSizeHalf, -cubeSizeHalf);
					rotateAxis = new Vector3(-1, 0, 0);
				}

				//��
				if (Input.GetKeyDown(KeyCode.UpArrow))
				{
					rotatePoint = transform.position + new Vector3(-cubeSizeHalf, -cubeSizeHalf, 0f);
					rotateAxis = new Vector3(0, 0, 1);
				}

				//��
				if (Input.GetKeyDown(KeyCode.DownArrow))
				{
					rotatePoint = transform.position + new Vector3(cubeSizeHalf, -cubeSizeHalf, 0f);
					rotateAxis = new Vector3(0, 0, -1);
				}

				// ���͂��Ȃ����̓R���[�`�����Ăяo���Ȃ��悤�ɂ���
				if (rotatePoint == Vector3.zero)
					return;

				StartCoroutine(MoveCube());
			}
			//�J�������
			else if((cameraRotate.count == 2 || cameraRotate.count == -2) && cameraRotate.rotateFlag == false)
            {
				//�E
				if (Input.GetKeyDown(KeyCode.RightArrow))
				{
					rotatePoint = transform.position + new Vector3(-cubeSizeHalf, -cubeSizeHalf, 0f);
					rotateAxis = new Vector3(0, 0, 1);
				}

				//��
				if (Input.GetKeyDown(KeyCode.LeftArrow))
				{
					rotatePoint = transform.position + new Vector3(cubeSizeHalf, -cubeSizeHalf, 0f);
					rotateAxis = new Vector3(0, 0, -1);
				}

				//��
				if (Input.GetKeyDown(KeyCode.UpArrow))
				{
					rotatePoint = transform.position + new Vector3(0f, -cubeSizeHalf, -cubeSizeHalf);
					rotateAxis = new Vector3(-1, 0, 0);
				}

				//��
				if (Input.GetKeyDown(KeyCode.DownArrow))
				{
					rotatePoint = transform.position + new Vector3(0f, -cubeSizeHalf, cubeSizeHalf);
					rotateAxis = new Vector3(1, 0, 0);
				}

				// ���͂��Ȃ����̓R���[�`�����Ăяo���Ȃ��悤�ɂ���
				if (rotatePoint == Vector3.zero)
					return;

				StartCoroutine(MoveCube());
			}
		}

	}

	IEnumerator MoveCube()�@
	{
		//��]���̃t���O�𗧂Ă�
		isRotate = true;

		//��]����
		float sumAngle = 0f; //angle�̍��v��ۑ�
		while (sumAngle < 90f)
		{
			cubeAngle = 5.0f; //������ς���Ɖ�]���x���ς��
			sumAngle += cubeAngle;

			// 90�x�ȏ��]���Ȃ��悤�ɒl�𐧌�
			if (sumAngle > 90f)
			{
				cubeAngle -= sumAngle - 90f;
			}
			transform.RotateAround(rotatePoint, rotateAxis, cubeAngle);

			yield return null;
		}

		//��]���̃t���O��|��
		isRotate = false;
		//Debug.Log("isRotate false");
		rotatePoint = Vector3.zero;
		rotateAxis = Vector3.zero;

		yield break;
	}

}