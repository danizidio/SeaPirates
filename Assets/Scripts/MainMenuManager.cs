using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Slider _gameTime, _spawnTime;

    void Start()
    {
        _spawnTime.GetComponent<Slider>().value = NavigationData.nData.SpawnTime;
        _gameTime.GetComponent<Slider>().value = NavigationData.nData.GameTime;
    }
}
