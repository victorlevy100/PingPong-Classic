using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{

    public Color colorPlayer = Color.white;
    public Color colorEnemy = Color.white;

    private static SaveController instance;

    public string playerName;
    public string enemyName;

    private string saveWinnerKey = "SavedWinner";

    public static SaveController GetInstance()
    {
        if (instance == null)
        {
            // Find the instance of the SaveController
            instance = FindAnyObjectByType<SaveController>();

            // If the instance is still null, create a new GameObject and add the SaveController component to it
            if (instance == null)
            {
                GameObject obj = new GameObject();
                obj.name = typeof(SaveController).Name;
                instance = obj.AddComponent<SaveController>();
            }
        }
        return instance;
    }

    private void Awake()
    {
        // If there is already an instance of SaveController, destroy the new one
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        // Set the instance to this object
        DontDestroyOnLoad(this.gameObject);

    }

    public string GetPlayerName(bool isPlayer)
    {
        return isPlayer ? playerName : enemyName;
    }

    public void Reset()
    {
        playerName = "";
        enemyName = "";
        colorPlayer = Color.white;
        colorEnemy = Color.white;
    }

    public void SaveWinner(string winner)
    {
       PlayerPrefs.SetString(saveWinnerKey, winner);
    }
    public string GetLastWinner()
    {
        return PlayerPrefs.GetString(saveWinnerKey);
    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteKey(saveWinnerKey);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
