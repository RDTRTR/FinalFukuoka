using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Stageselect");
    }
}
