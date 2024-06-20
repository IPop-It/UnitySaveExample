using Newtonsoft.Json;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Data
{
    public int Score;   
}

public class SaveManager : MonoBehaviour
{
    public Data Data;

    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);
    [DllImport("__Internal")]
    private static extern void LoadExtern();

    public static SaveManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Data = new Data();
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
            LoadExtern();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Load()
    {
        LoadExtern();
    }

    public void Save()
    {
        string jsonString = JsonConvert.SerializeObject(Data);
#if UNITY_WEBGL
        SaveExtern(jsonString);
#endif
    }

    public void SetData(string value)
    {
        Data = JsonConvert.DeserializeObject<Data>(value);
    }

    public void LoadedData()
    {
        SceneManager.LoadScene("GameScene");
    }

}
