using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    [SerializeField] GameObject _lifeCanvas;
    [Space(10)]

    [SerializeField] float _maxLife;
    float _currentLife;
    
    [SerializeField] SpriteRenderer _pieceHull, _pieceLargeSail, _pieceSmallSail, _pieceFlag;
    
    [SerializeField] Sprite[] _hull;
    [SerializeField] Sprite[] _largeSail;
    [SerializeField] Sprite[] _smallSail;
    [SerializeField] Sprite[] _flag;


    private void Start()
    {
        _currentLife = _maxLife;
        
        _pieceHull.sprite = _hull[0];
        _pieceLargeSail.sprite = _largeSail[0];
        _pieceSmallSail.sprite = _smallSail[0];
        _pieceFlag.sprite = _flag[0];

       GameObject temp = Instantiate(_lifeCanvas, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
       temp.GetComponent<LifeCanvas>().ShipToFollow(this.transform);
    }
    
    public void TakingDamage(float damageTaken)
    {
        _currentLife -= damageTaken;
        
        float _percentageLife = _currentLife/_maxLife;
        
        if (_percentageLife >= .31f && _percentageLife <= .7f)
        {
            _pieceHull.sprite = _hull[1];
            _pieceLargeSail.sprite = _largeSail[1];
            _pieceSmallSail.sprite = _smallSail[1];
        }
        
        if(_percentageLife >= .01f && _percentageLife <= .3f)
        {
            _pieceHull.sprite = _hull[2];
            _pieceLargeSail.sprite = _largeSail[2];
            _pieceSmallSail.sprite = _smallSail[2];
        }
        
        if(_currentLife <= 0)
        {
            _currentLife = 0;
            
            _pieceHull.sprite = _hull[3];
            _pieceLargeSail.sprite = _largeSail[3];
            _pieceSmallSail.sprite = _smallSail[3];
            _pieceFlag.sprite = _flag[1];
        }

        _lifeCanvas.GetComponent<LifeCanvas>().UpdateLifeBar(_currentLife, _maxLife);
    }
}

