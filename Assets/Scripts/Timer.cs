using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

  [SerializeField] TMP_Text _txt;
    
	float _progressiveTimer;
	float _regressiveTimer;

	 bool _isTicTimer;
	public bool IsTicTimer { get { return _isTicTimer; } }

	 bool _itsOver;

	[SerializeField] float _progressiveTimer_Microseconds;
	[Space(10)]

	[SerializeField] float _regressiveTimer_Minutes;
	float _regressiveTimer_Seconds;
	float _regressiveTimer_Miliseconds;
	float _regressiveTimer_Microseconds;


    private void Start()
    {
		try
        {
			_regressiveTimer_Minutes = NavigationData.nData.GameTime;
		}
		catch
        {
			_regressiveTimer_Minutes = 3;

		}  
    }

    void Update()
	{
		RegressiveTimer();
    
		_txt.text = string.Format("{0:00}:{1:00}:{2:00}", _regressiveTimer_Minutes, _regressiveTimer_Seconds, _regressiveTimer_Miliseconds);
	}

	void RegressiveTimer()
    {
		if(IsTicTimer)
        {
			_regressiveTimer -= Time.deltaTime;
			_regressiveTimer_Microseconds = Mathf.RoundToInt(_regressiveTimer * 600);

			if (_regressiveTimer_Microseconds <= 0)
			{
				_regressiveTimer_Microseconds = 59;
				_regressiveTimer_Miliseconds--;
			}
			if (_regressiveTimer_Miliseconds <= 0)
			{
				_regressiveTimer_Miliseconds = 59;
				_regressiveTimer_Seconds--;
			}
			if (_regressiveTimer_Seconds <= 0)
			{
				_regressiveTimer_Seconds = 59;
				_regressiveTimer_Minutes--;
			}
			if(_regressiveTimer_Minutes <= 0)
            {
				GameBehaviour.OnNextGameState.Invoke(GamePlayStates.GAMEOVER);
			}
		}
    }
}
