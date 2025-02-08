using TMPro;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public TextMeshProUGUI uiWinner;
    void Start()
    {
        SaveController.GetInstance().Reset();
        string lastWinner = SaveController.GetInstance().GetLastWinner();
        if (lastWinner != "")
        {
            uiWinner.text = "�ltimo vencedor: " + lastWinner;
        }
        else
        {
            uiWinner.text = "";
        }
    }
}
