using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager UIManager;
    [SerializeField] private GameObject GameOver;
    [SerializeField] private GameObject UIPanel;
    [SerializeField] private Texture2D cursor;

    void Start()
    {
        Cursor.SetCursor(cursor, new Vector2(16, 16), CursorMode.ForceSoftware);
        UIPanel.SetActive(true);
        GameOver.SetActive(false);
    }

    public IEnumerator Die()
    {
        UIPanel.SetActive(false);
        UIManager.GetComponent<UIManager>().FinalScoreTime();
        yield return new WaitForSeconds(2);
        GameOver.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Play()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
