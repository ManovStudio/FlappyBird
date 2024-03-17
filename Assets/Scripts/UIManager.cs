using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text textCoin;

    public LevelManager LevelManager;

    public void UpdateCoin()
    {
        textCoin.text = LevelManager.GetScore().ToString() + "/" + LevelManager.GetTaskScore().ToString();
    }
}
