using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationData : MonoBehaviour
{
    public static NavigationData nData;

    [SerializeField] OptionsValues optionsValues;

    [SerializeField] int _targetFrameRate;

    float _gameTime, _spawnTime;
    public float GameTime { get { return optionsValues.GameSessionTime; } }
    public float SpawnTime { get { return optionsValues.EnemySpawnTime; } }

    static int _highScore;

    GameObject[] Datas;

    private void Awake()
    {
        nData = this;
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        Datas = GameObject.FindGameObjectsWithTag("NAVIGATION_DATA");

        if (Datas.Length > 1)
        {
            Destroy(Datas[1]);
        }

        _highScore = optionsValues.HighScore;

        Application.targetFrameRate = _targetFrameRate;
    }

    public void ChangingGameTime(float v)
    {
        _gameTime = v;

        optionsValues.GameSessionTime = _gameTime;
    }
    public void ChangingSpawnTime(float v)
    {
        _spawnTime = v;

        optionsValues.EnemySpawnTime = _spawnTime;
    }

    public void SetHighScore(int value)
    {
        _highScore = value;

        optionsValues.HighScore = _highScore;
    }

    public static int GetHighScore()
    {
        return _highScore;
    }
}
