using UnityEngine;

public class ResetData : MonoBehaviour
{
    public void ClearData()
    {
        SaveController.GetInstance().ClearSave();
    }
}
