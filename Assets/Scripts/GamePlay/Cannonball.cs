using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    [SerializeField] GameObject _explosion;

    [SerializeField] int _damage;
    [SerializeField] float _speed;

    Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _rb.velocity = Vector2.right * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponentInParent<ShipBehaviour>().TakingDamage(_damage);

            Instantiate(_explosion, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
