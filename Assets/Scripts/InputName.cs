using UnityEngine;

public class InputName : MonoBehaviour
{
    public bool isPlayerName = false;
    public TMPro.TMP_InputField inputField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        inputField.onValueChanged.AddListener(UpdateName);


    }

    // Update is called once per frame
    public void UpdateName(string name)
    {
        if (isPlayerName)
        {
            SaveController.GetInstance().playerName = name;
        }
        else
        {
            SaveController.GetInstance().enemyName = name;
        }
    }
}
