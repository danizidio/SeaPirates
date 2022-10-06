using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    [SerializeField] int _maxLife;
    int _currentLife;

    [SerializeField] Sprite[] _hull;
    [SerializeField] Sprite[] _largeSail;
    [SerializeField] Sprite[] _smallSail;

    private void Start()
    {
        _currentLife = _maxLife;
    }
}

