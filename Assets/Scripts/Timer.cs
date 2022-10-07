using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

  [SerializeField] TMP_Text txt;
    
	float _progressiveTimer;
	float _regressiveTimer;

	[SerializeField] bool _isTicTimer;
	public bool IsTicTimer { get { return _isTicTimer; } }

	[SerializeField] bool itsOver;

	float hour;

	[SerializeField] float _progressiveTimer_Minutes;
	public float Progressive_Minutes { get { return _progressiveTimer_Minutes; } }
	[SerializeField] float _progressiveTimer_Seconds;
	public float Progressive_Seconds { get { return _progressiveTimer_Seconds; } }
	[SerializeField] float _progressiveTimer_Miliseconds;
	public float Progressive_Miliseconds { get { return _progressiveTimer_Miliseconds; } }

	[SerializeField] float _progressiveTimer_Microseconds;
	[Space(10)]

	[SerializeField] float _regressiveTimer_Minutes;
	[SerializeField] float _regressiveTimer_Seconds;
	[SerializeField] float _regressiveTimer_Miliseconds;
	[SerializeField] float _regressiveTimer_Microseconds;

	void Update()
	{
		RegressiveTimer();
    
    txt.text = string.Format("{0:00}:{1:00}:{2:00}", _regressiveTimer_Minutes, _regressiveTimer_Seconds, _regressiveTimer_Miliseconds);
	}

	void ProgressiveTimer()
    {
		if(IsTicTimer)
        {
			_progressiveTimer += Time.deltaTime;

			_progressiveTimer_Microseconds = Mathf.RoundToInt(_progressiveTimer * 600);

			if (_progressiveTimer_Microseconds >= 59)
			{
				_progressiveTimer_Microseconds = 0;
				_progressiveTimer_Miliseconds++;
			}
			if (_progressiveTimer_Miliseconds >= 59)
			{
				_progressiveTimer_Miliseconds = 00;
				_progressiveTimer_Seconds++;
			}
			if (_progressiveTimer_Seconds >= 59)
			{
				_progressiveTimer_Seconds = 00;
				_progressiveTimer_Minutes++;
			}
			if (_progressiveTimer_Minutes >= 59)
			{
				_progressiveTimer_Minutes = 00;
				hour++;
			}
		}
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
				//CODIGO AQUI
            }
		}
    }
}
