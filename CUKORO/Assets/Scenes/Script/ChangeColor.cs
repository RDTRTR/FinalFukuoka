using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    // Unityエディタ上で変えたい色を指定できる。
    public Color color;
    public GameObject plane;
    bool changeflag = false;
    public panelsetcolor mycolor = panelsetcolor.White;
    public GameObject playSound; //SE

    //オブジェクトが衝突したとき
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Blue")
        {
            var change = other.gameObject.GetComponent<Renderer>().material;

            plane.gameObject.GetComponent<Renderer>().material = change;

            mycolor = panelsetcolor.Blue;

            playSound.SendMessage("OnStart");

        }

        if (other.gameObject.name == "Red")
        {
            var change = other.gameObject.GetComponent<Renderer>().material;

            plane.gameObject.GetComponent<Renderer>().material = change;

            mycolor = panelsetcolor.Red;

        }
        
        
    }
}