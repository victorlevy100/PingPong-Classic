using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform playerPaddle;
    public Transform enemyPaddle;
    public BallController ballController;
    public int playerScore = 0;
    public int enemyScore = 0;
    public int winPoints = 2;

    public TextMeshProUGUI textPointsPlayer;
    public TextMeshProUGUI textPointsEnemy;

    public EndGameUIController endGameUIController; 
    public float endGameDelay = 0.01f;

    public TextMeshProUGUI textEndGame;


    void Start()
    {
       ResetGame();
    }



    public void ResetGame()
    {
        playerPaddle.position = new Vector3(-7.5f, 0, 0);
        enemyPaddle.position = new Vector3(7.5f, 0, 0);

        ballController.ResetBall();

        playerScore = 0;
        enemyScore = 0;

        textPointsEnemy.text = enemyScore.ToString();
        textPointsPlayer.text = playerScore.ToString();
    }

    public void PlayerScored()
    {
        playerScore++;
        textPointsPlayer.text = playerScore.ToString();
        CheckWin();
    }

    public void EnemyScored()
    {
        enemyScore++;
        textPointsEnemy.text = enemyScore.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
        if (playerScore >= winPoints)
        {
            Debug.Log("Player wins!");
            StartCoroutine(ShowEndGamePanelWithDelay());
        }
        else if (enemyScore >= winPoints)
        {
            Debug.Log("Enemy wins!");
            StartCoroutine(ShowEndGamePanelWithDelay());
        }
    }

    private System.Collections.IEnumerator ShowEndGamePanelWithDelay()
    {
        
        yield return new WaitForSeconds(endGameDelay);
        string winner = SaveController.GetInstance().GetPlayerName(playerScore > enemyScore);
        textEndGame.text = "Vitória " + winner;
        SaveController.GetInstance().SaveWinner(winner);
        endGameUIController.ShowEndGamePanel();
        
    }
}
