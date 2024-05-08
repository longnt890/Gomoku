using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverWindown : MonoBehaviour
{
    public Text winnerName;

    public Button restartButton;

    public void SetName(string s)
    {
        winnerName.text = s;
    }

    public void OnClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
