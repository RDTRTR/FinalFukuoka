using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove2 : MonoBehaviour
{
    GameObject target;
    Vector3 targetPos;

    void Start()
    {
        //追尾目的のオブジェクトを見つけて情報を取得
        target = GameObject.Find("Cube");
    }

    void Update()
    {
        //Robot2が移動した分、カメラも移動
        transform.position += target.transform.position - targetPos;
        targetPos = target.transform.position;

        //Robo2を中心にYを軸として回転
        transform.RotateAround(targetPos, Vector3.up, 50.0f * Time.deltaTime);

    }
}