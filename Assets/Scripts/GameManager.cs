using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleTon<GameManager>
{
    private string SAVE_DATA_PATH;
    private string SAVE_FILE_NAME = "/SaveFile.txt";
    public User CurrentUser { get; private set; }

    private UIManager uiManager = null;

    public UIManager UI { get { return uiManager; } }

    [SerializeField]
    private Transform pool = null;
    public Transform Pool { get { return pool; } }

    private void Awake()
    {
        SAVE_DATA_PATH = Application.persistentDataPath;
        LoadFromJson();
        InvokeRepeating("SaveToJson", 1f, 60f);
        InvokeRepeating("EarnFishPerSecond", 0f, 1f);
    }

    public void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    public void EarnFishPerSecond()
    {
        foreach (Ability ability in CurrentUser.abilityList)
        {
            CurrentUser.fish += ability.Fps * ability.Amount;
        }
        UI.UpdateFishPanel();
    }

    private void LoadFromJson()
    {
        string jsonString = "";
        if(File.Exists(SAVE_DATA_PATH + SAVE_FILE_NAME) == true)
        {
            jsonString = File.ReadAllText(SAVE_DATA_PATH  + SAVE_FILE_NAME);
            CurrentUser = JsonUtility.FromJson<User>(jsonString);
        }
        else
        {
            CurrentUser = new User();
            CurrentUser.userName = "떼껄룩사원";
            CurrentUser.fish = 0;
            CurrentUser.abilityList = new List<Ability>();
            CurrentUser.abilityList.Add(new Ability("클릭 증가", 0, 0, 0, 5));
            CurrentUser.abilityList.Add(new Ability("커피 타오기", 1, 0, 3, 20));
            CurrentUser.abilityList.Add(new Ability("주변 정리", 2, 0, 9, 80));
            CurrentUser.abilityList.Add(new Ability("물 채우기", 3, 0, 27, 320));
            CurrentUser.abilityList.Add(new Ability("회의하기", 4, 0, 81, 1280));
            CurrentUser.abilityList.Add(new Ability("회계부 정리", 5, 0, 243, 5120));
            CurrentUser.abilityList.Add(new Ability("보고서 작성", 6, 0, 729, 20480));
            CurrentUser.abilityList.Add(new Ability("차트 만들기", 7, 0, 2187, 81920));
            CurrentUser.abilityList.Add(new Ability("칭찬받기", 8, 0, 6561, 327680));
            CurrentUser.abilityList.Add(new Ability("휴식하기", 9, 0, 19683, 1310720));
            CurrentUser.abilityList.Add(new Ability("승진하기", 10, 0, 59049, 5242880));
            SaveToJson();
        }
    }

    private void SaveToJson()
    {
        string json = JsonUtility.ToJson(CurrentUser);
        File.WriteAllText(SAVE_DATA_PATH + SAVE_FILE_NAME, json, System.Text.Encoding.UTF8);
    }

    public void OnApplicationQuit()
    {
        SaveToJson();
    }
}
