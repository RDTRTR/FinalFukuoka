using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    //プレイヤーを変数に格納
    public GameObject Player;

    bool rotateFlag = false;

    public float nowAngle;

    //回転させる角度
    private float angle = 90;

    //プレイヤー位置情報
    //Vector3 playerPos = Player.transform.position;

    
    void Start()
    {
        
    }

   
    void Update()
    {

        
        //カメラを回転させる
        //左クリック
        if (Input.GetMouseButton(0) && Input.GetMouseButtonDown(0))
        {
            if (!rotateFlag)
            {
                rotateFlag = true;
                StartCoroutine(LeftMove());
            }

        }

        //右クリック
        if (Input.GetMouseButton(1) && Input.GetMouseButtonDown(1))
        {
           if(!rotateFlag)
            {
                rotateFlag = true;
                StartCoroutine(RightMove());
            }

        }
        

    }

    
    //右回転
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

    //左回転
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