using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Reset : MonoBehaviour
{
    [SerializeField] private GameObject HighScoreReset;
    [SerializeField] private GameObject BestTimeReset;
    // Start is called before the first frame update
    void Start()
    {
        HighScoreReset.SetActive(false);
        BestTimeReset.SetActive(false);
    }

    public void ResetButton()
    {
        if (HighScoreReset.activeSelf == true)
        {
            HighScoreReset.SetActive(false);
            BestTimeReset.SetActive(false);
        }
        else
        {
            HighScoreReset.SetActive(true);
            BestTimeReset.SetActive(true);
        }
        
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        ResetButton();
    }

    public void ResetBestTime()
    {
        PlayerPrefs.DeleteKey("LongestTime");
        ResetButton();
    }
}
