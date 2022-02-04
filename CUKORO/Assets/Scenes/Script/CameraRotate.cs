using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    //�v���C���[��ϐ��Ɋi�[
    public GameObject Player;

    bool rotateFlag = false;

    public float nowAngle;

    //��]������p�x
    private float angle = 90;

    //�v���C���[�ʒu���
    //Vector3 playerPos = Player.transform.position;

    
    void Start()
    {
        
    }

   
    void Update()
    {

        
        //�J��������]������
        //���N���b�N
        if (Input.GetMouseButton(0) && Input.GetMouseButtonDown(0))
        {
            if (!rotateFlag)
            {
                rotateFlag = true;
                StartCoroutine(LeftMove());
            }

        }

        //�E�N���b�N
        if (Input.GetMouseButton(1) && Input.GetMouseButtonDown(1))
        {
           if(!rotateFlag)
            {
                rotateFlag = true;
                StartCoroutine(RightMove());
            }

        }
        

    }

    
    //�E��]
    IEnumerator RightMove()
    {

        Vector3 playerPos = Player.transform.position;

        for (int turn = 0; turn < 90; turn++)
        {

            transform.RotateAround(playerPos, -Vector3.up, 1);


            //if (transform.eulerAngles.y + 1 >= 360)
            //{
            //    transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
            //    Debug.Log(transform.eulerAngles.y);
            //    break;

            //}

            yield return new WaitForSeconds(0.01f);



        }

       

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Round(transform.eulerAngles.y), transform.eulerAngles.z);

        nowAngle = transform.rotation.eulerAngles.y;

        

        //Debug.Log(Mathf.Round(transform.rotation.eulerAngles.y));
        rotateFlag = false;
    }

    //����]
    IEnumerator LeftMove()
    {

        Vector3 playerPos = Player.transform.position;

        for (int turn = 0; turn < 90; turn++)
        {

            transform.RotateAround(playerPos, Vector3.up, 1);

            //if (transform.eulerAngles.y + 1 >= 360)
            //{
            //    transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
            //    Debug.Log(transform.eulerAngles.y);
            //    break;

            //}

            yield return new WaitForSeconds(0.01f);


        }

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Round(transform.eulerAngles.y), transform.eulerAngles.z);

        nowAngle = transform.rotation.eulerAngles.y;

        

        //Debug.Log(Mathf.Round(transform.rotation.eulerAngles.y));
        rotateFlag = false;
    }

}