using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasGame : MonoBehaviour
{
    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _resume;
    [SerializeField] private GameObject _pauseMenu;

    public void Start()
    {
        _pauseMenu.SetActive(false);
        _resume.SetActive(false);
        _pause.SetActive(true);
    }
    #region Pause
    public void PauseButton()
    {
        _pause.SetActive(false);
        _resume.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeButton()
    {
        _resume.SetActive(false);
        _pause.SetActive(true);
        Time.timeScale = 1;
    }

    #endregion

    #region GameOver
    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
    #endregion


}
