using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCannons : MonoBehaviour
{
    [SerializeField] GameObject _singleShot;
    [SerializeField] GameObject _tripleShot;

    [SerializeField] Transform _leftShot, _rightShot, _frontShot;


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(_singleShot, new Vector2(_frontShot.position.x, _frontShot.position.y -1), Quaternion.identity);
        }
        if (Input.GetMouseButtonDown(1))
        {

        }
    }
}
