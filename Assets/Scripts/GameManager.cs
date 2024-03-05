using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float killCount;
    public TextMeshProUGUI killCountText;
    public TextMeshProUGUI highKillCountText;

    public GameObject pauseMenuUI;
    public GameObject winLevelUI;

    private bool gameIsPaused = false;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused == true)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void WinLevel()
    {
        winLevelUI.SetActive(true);
        highKillCountText.text = killCount + " aliens were killed!";
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void AddKill()
    {
        killCount++;
        killCountText.text =killCount.ToString();
    }
}
