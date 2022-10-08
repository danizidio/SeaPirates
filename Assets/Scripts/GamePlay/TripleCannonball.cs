using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleCannonball : MonoBehaviour
{
    [SerializeField] GameObject _cannonball;
    [SerializeField] GameObject[] _instantiatedShots;


    [SerializeField] int _damage;
    [SerializeField] float _speed;
    public float Speed { get { return _speed; } }

    private void Update()
    {
        if(_instantiatedShots == null)
        {
            Destroy(gameObject);
        }
    }

    public void ShotDirection()
    {
        StartCoroutine(SpawnShots());
    }

    IEnumerator SpawnShots()
    {
        _instantiatedShots[0] = Instantiate(_cannonball, new Vector2(this.transform.position.x, this.transform.position.y),
            Quaternion.Euler(this.transform.position.x, this.transform.position.y, this.transform.rotation.z));

        _instantiatedShots[0].GetComponent<Rigidbody2D>().velocity = this.transform.right * Speed;

        yield return new WaitForSeconds(.1f);

        _instantiatedShots[1] = Instantiate(_cannonball, new Vector2(this.transform.position.x, this.transform.position.y - .6f),
            Quaternion.Euler(transform.position.x, transform.position.y, transform.rotation.z));

        _instantiatedShots[1].GetComponent<Rigidbody2D>().velocity = this.transform.right * Speed;

        _instantiatedShots[2] = Instantiate(_cannonball, new Vector2(transform.position.x, transform.position.y + .6f),
            Quaternion.Euler(transform.position.x, transform.position.y, transform.rotation.z));

        _instantiatedShots[2].GetComponent<Rigidbody2D>().velocity = this.transform.right * Speed;
    }
}
