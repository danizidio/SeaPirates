using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    [SerializeField] GameObject _explosion;

    [SerializeField] int _damage;
    [SerializeField] float _speed;
    public float Speed { get { return _speed; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICanBeDamaged _iCanBeDamaged = collision.GetComponentInParent<ICanBeDamaged>();

        if (_iCanBeDamaged != null)
        {
            _iCanBeDamaged.TakingDamage(_damage);

            Instantiate(_explosion, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void ShotDirection(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * Speed;
    }
}
