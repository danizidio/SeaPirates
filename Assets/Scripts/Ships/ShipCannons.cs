using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCannons : MonoBehaviour
{
    [SerializeField] GameObject _singleShot;
    [SerializeField] GameObject _tripleShot;

    [SerializeField] Transform _sideShot,  _frontShot;

    bool _canShoot = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _canShoot)
        {
            StartCoroutine(CannonShot(_singleShot, _frontShot, 1));
        }
        if (Input.GetMouseButtonDown(1) && _canShoot)
        {
            StartCoroutine(CannonShot(_tripleShot, _sideShot, 3));
        }
    }

    IEnumerator CannonShot(GameObject ballType, Transform shotSide, float timing)
    {
        _canShoot = false;

        GameObject temp = Instantiate(ballType, new Vector2(shotSide.position.x, shotSide.position.y), Quaternion.Euler(shotSide.position.x, shotSide.position.y,shotSide.rotation.z));

        try
        {
            temp.GetComponent<Cannonball>().ShotDirection(shotSide.right);
        }
        catch 
        {
            temp.GetComponent<TripleCannonball>().ShotDirection();
        }
        
        yield return new WaitForSeconds(timing);

        _canShoot = true;

        StopCoroutine("CannonShot");
    }
}
