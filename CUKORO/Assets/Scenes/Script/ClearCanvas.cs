using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearCanvas : MonoBehaviour
{

    public GameObject panel; //パネルを決める

    public Text clearText; //テキストを決める
    




    // Start is called before the first frame update
    void Start()
    {
        //ゲームが始まったら隠す
        panel.SetActive(false);
    }

    void OnEnter()
    {
        //プレイヤーからメッセージが送られてきたら表示
        panel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
