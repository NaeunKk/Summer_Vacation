using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;


public class JsonManager : MonoBehaviour
{
    public static JsonManager instance;
    private string SAVE_PATH = "";
    private string SAVE_FILENAME = "/SaveFile.txt";
    [SerializeField] private JsonData data = null;
    public JsonData Data { get { return data; } }

    #region UI
    public TextMeshProUGUI statisticTxt;
    /*public Text floatText;
    public Text stringText;
    public Text boolText;
    public Image spriteImgae;*/
    #endregion
    private void Start()
    {
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        Load();
    }

    [ContextMenu("불러오기")]
    public void Load()
    {
        Init();
        string json = "";
        if (File.Exists(SAVE_PATH + SAVE_FILENAME) == true)
        {
            json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME);
            data = JsonUtility.FromJson<JsonData>(json);
        }
    }
    [ContextMenu("저장")]
    public void Save()
    {
        Init();
        //print("AA");
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8);

    }
    private void Update()
    {
        DisplayUI();
    }
    public void Init()
    {
        SAVE_PATH = Application.dataPath + "/Save";
        if (Directory.Exists(SAVE_PATH) == false)
        {
            Directory.CreateDirectory(SAVE_PATH);
        }
    }

    public void DisplayUI()
    {
        statisticTxt.text = $"HP: {data.curHp} / {data.maxHp}\nPotion - {data.healPotionNum}\nDamage -" +
            $" {data.curDamage}\nSpeed - {data.curSpeed}\nPoint - {data.point}";
    }
}
