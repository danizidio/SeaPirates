using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySpawner : MonoBehaviour
{
    Action timerCallBack;

    float _timer;

    [SerializeField] GameObject[] _spawnPlaces;

    [SerializeField] GameObject[] _enemyShips;

    private void Start()
    {
        FindSpawnPlaces();

        try
        {
            _timer = NavigationData.nData.SpawnTime;
        }
        catch
        {
            _timer = 2;
        }

        SetTimer(_timer, () => SpawnEnemy());
    }

    private void Update()
    {
        CountDown();
    }

    public void CountDown()
    {
        if (_timer > 0f)
        {
            _timer -= Time.deltaTime;

            if (TimerIsComplete())
            {
                timerCallBack?.Invoke();
            }
        }
    }

    public void SetTimer(float timer, Action timerCallBack)
    {
        this._timer = timer;
        this.timerCallBack = timerCallBack;
    }

    public bool TimerIsComplete()
    {
        return _timer <= 0;
    }

    void FindSpawnPlaces()
    {
        _spawnPlaces = GameObject.FindGameObjectsWithTag("SPAWNPLACE");
    }

    void SpawnEnemy()
    {
        Transform temp = _spawnPlaces[UnityEngine.Random.Range(0, _spawnPlaces.Length)].transform;

        Instantiate(_enemyShips[UnityEngine.Random.Range(0, _enemyShips.Length)], new Vector2(temp.position.x, temp.position.y), Quaternion.identity);
    }
}
