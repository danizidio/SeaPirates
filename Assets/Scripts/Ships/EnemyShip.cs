using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShipType
{
    NULL,
    CHASER,
    SHOOTER
}

public class EnemyShip : MonoBehaviour
{
    [SerializeField] ShipType _shipType;

    [SerializeField] int _hullHitDamage;

    [SerializeField] GameObject _explosion;

    [SerializeField] float _stopDistance;
    GameObject _target;

    Rigidbody2D _rb;

    [SerializeField] float _accelerationPower;
    [SerializeField] float _steeringPower;
    float _steeringAmount, _speed, _direction;

    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");

        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
       if(_shipType == ShipType.CHASER)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        Vector3 localPosition = _target.transform.position - transform.position;
        localPosition = localPosition.normalized;

        _steeringAmount = -localPosition.x;

        _speed = -1 * _accelerationPower;
        _direction = Mathf.Sign(Vector2.Dot(_rb.velocity, _rb.GetRelativeVector(Vector2.up)));

        _rb.rotation += _steeringAmount * _steeringPower * _rb.velocity.magnitude * _direction;

        _rb.AddRelativeForce(Vector2.up * _speed);

        _rb.AddRelativeForce(-Vector2.right * _rb.velocity.magnitude * _steeringAmount / 2);
    }

    public void ShipWrecked()
    {
        _accelerationPower = 0;
        _steeringPower = 0;

        GameBehaviour.OnEarningPoints?.Invoke();

        StartCoroutine(DestroingGameObject());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ICanBeDamaged _iCanBeDamaged = collision.collider.GetComponentInParent<ICanBeDamaged>();

        if (_iCanBeDamaged != null && _shipType == ShipType.CHASER)
        {
            _iCanBeDamaged.TakingDamage(_hullHitDamage);

            GameObject temp = Instantiate(_explosion, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            temp.transform.localScale = new Vector2(3, 3);

            StartCoroutine(DestroingGameObject());
        }
    }

    IEnumerator DestroingGameObject()
    {
        yield return new WaitForSeconds(1);

        GetComponent<ShipBehaviour>().DestroyCanvas();
        Destroy(gameObject);

    }
}
