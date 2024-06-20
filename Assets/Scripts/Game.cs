using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    public TMP_Text text;

    private void Start()
    {
        text.text = SaveManager.Instance.Data.Score.ToString();
    }

    private void UpdateText()
    {
        text.text = SaveManager.Instance.Data.Score.ToString();
    }


    public void IncrementScore()
    {
        SaveManager.Instance.Data.Score++;
        SaveManager.Instance.Save();
        UpdateText();
    }

    public void DecrementScore() 
    {
        SaveManager.Instance.Data.Score--;
        SaveManager.Instance.Save();
        UpdateText();
    }
}
