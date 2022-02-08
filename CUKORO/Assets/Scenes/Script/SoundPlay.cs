using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundPlay : MonoBehaviour
{
    public AudioSource Audio;
    public AudioSource Audio2;


    public AudioClip clear;//AudioSourceを入れる
    public AudioClip rotate;
    bool isAudioStart = false; //曲再生の判定

    // Start is called before the first frame update
    void Start()
    {
       
    }

    void OnEnter()
    {
       
        Audio.PlayOneShot(clear);//AudioSourceを再生
        
        isAudioStart = true;//曲の再生を判定

        if (!Audio.isPlaying && isAudioStart)
        //曲が再生されていない、尚且つ曲の再生が開始されている時
        {
            Destroy(gameObject);//オブジェクトを消す
        }
    }

    void OnStart()
    {
        if (Audio != null)
        {
            Audio2.PlayOneShot(rotate);//AudioSourceを再生
        }

        isAudioStart = true;//曲の再生を判定
        if (!Audio2.isPlaying && isAudioStart)
        //曲が再生されていない、尚且つ曲の再生が開始されている時
        {
            Destroy(gameObject);//オブジェクトを消す
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
