using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text score;
    public Text timeSinceStart;
    private int points;
    public float tSS;
    private int FinalScore;
    private int FinalTime;
    [SerializeField] private Text EndScore;
    [SerializeField] private Text EndTime;
    [SerializeField] private Text HighScore;
    [SerializeField] private Text LongTime;
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        tSS = 0;
    }

    // Update is called once per frame
    void Update()
    {
        tSS += Time.deltaTime;
        timeSinceStart.text = Mathf.FloorToInt(tSS).ToString();
    }

    public void AddPoints(int Points)
    {
        points += Points;
        score.text = points.ToString();
    }

    public void FinalScoreTime()
    {
        FinalScore = points;
        FinalTime = Mathf.FloorToInt(tSS);
        EndScore.text = FinalScore.ToString();
        EndTime.text = FinalTime.ToString();
        if (FinalScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", FinalScore);
        }
        if (FinalTime > PlayerPrefs.GetInt("LongestTime"))
        {
            PlayerPrefs.SetInt("LongestTime", FinalTime);
        }
        LongTime.text = PlayerPrefs.GetInt("LongestTime").ToString();
        HighScore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
}
