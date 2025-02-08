using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameUIController : MonoBehaviour
{
    public GameObject endGamePanel;
    
         
    void Start()
    {
        endGamePanel.SetActive(false);
    }

    public void ShowEndGamePanel()
    {
        Time.timeScale = 0f;
        endGamePanel.SetActive(true);
        
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}