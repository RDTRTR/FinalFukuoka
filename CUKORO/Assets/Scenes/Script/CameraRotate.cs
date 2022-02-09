using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraRotate : MonoBehaviour
{
    //オブジェクトを変数に格納
    public GameObject Stage;
    public GameObject Camera;

    public bool rotateFlag = false;

    //今カメラがいる場所を把握する
    public int count;

    void Start()
    {
        
    }

    void Update()
    {

        //ボタンがクリックされた時だけ反応する
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        //ステージ位置情報
        Vector3 stagePos = Stage.transform.position;

        //カメラを回転させる
        //左クリック
        if (Input.GetMouseButton(0) && Input.GetMouseButtonDown(0))
        {
            //カメラが回っているときは操作できないようにする
            if (!rotateFlag)
            {
                rotateFlag = true;

                count += 1;

                //一周したらカウントをリセット
                if (count > 3)
                {
                    count = 0;
                }

               // Debug.Log(count);

                //左回転呼び出し
                StartCoroutine(LeftMove());
            }

        }

        //右クリック
        if (Input.GetMouseButton(1) && Input.GetMouseButtonDown(1))
        {
            //カメラが回っているときは操作できないようにする
            if (!rotateFlag)
            {
                rotateFlag = true;

                //今いる場所を更新
                count -= 1;

                //一周したらカウントをリセット
                if (count < -3)
                {
                    count = 0;
                }

                //Debug.Log(count);

                //右回転呼び出し
                StartCoroutine(RightMove());
            }

        }

    }


    //右回転
    IEnumerator RightMove()
    {
        //中心を決める
        Vector3 playerPos = Stage.transform.position;

        //回転処理 0.01秒で1度回転する(1秒で90度)
        for (int turn = 0; turn < 90; turn++)
        {
            transform.RotateAround(playerPos, new Vector3(0, -1, 0), 1.0f);
            yield return new WaitForSeconds(0.01f);
        }

        //回転中は回転しないようにする
        rotateFlag = false;

    }

    //左回転
    IEnumerator LeftMove()
    {
        //中心を決める
        Vector3 playerPos = Stage.transform.position;

        //回転処理 0.01秒で1度回転する(1秒で90度)
        for (int turn = 0; turn < 90; turn++)
        {
            transform.RotateAround(playerPos, new Vector3(0, 1, 0), 1.0f);
            yield return new WaitForSeconds(0.01f);
        }

        //回転中は回転しないようにする
        rotateFlag = false;

    }

}