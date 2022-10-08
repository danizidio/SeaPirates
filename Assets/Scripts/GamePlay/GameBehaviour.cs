
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    public delegate GamePlayStates _onNextGameState(GamePlayStates gameStates);
    public static _onNextGameState OnNextGameState;

    GamePlayStates _gamePlayPreviousState;
    public GamePlayStates GamePlayPreviousState { get { return _gamePlayPreviousState; } }
    
    [SerializeField] GamePlayStates _gamePlayCurrentState;
    public GamePlayStates GamePlayCurrentState { get { return _gamePlayCurrentState; } }
    
    GamePlayStates _gamePlayNextState;
    public GamePlayStates GamePlayNextState { get { return _gamePlayNextState; } }

    [SerializeField] GameObject[] _playerShips;
    GameObject _currentPlayerShip;

    [SerializeField] GameObject[] _stages;

    GameObject _currentStage;

    private void Start()
    {
        OnNextGameState(GamePlayStates.INITIALIZING);
    }

    private void Update()
    {
        StateBehaviour(GamePlayCurrentState);

        UpdateState();
    }

    void StateBehaviour(GamePlayStates state)
    {
        switch (state)
        {
            case GamePlayStates.INITIALIZING:
                {
                    if(_currentStage != null)
                    {
                        Destroy(_currentStage);

                        _currentStage = Instantiate(_stages[Random.Range(0, _stages.Length)]);
                    }
                    else
                    {
                        _currentStage = Instantiate(_stages[Random.Range(0, _stages.Length)]);
                    }

                    if (_currentPlayerShip != null)
                    {
                        Destroy(_currentPlayerShip);

                        _currentPlayerShip = Instantiate(_playerShips[Random.Range(0, _playerShips.Length)], new Vector2(0, 0), Quaternion.identity);
                    }
                    else
                    {
                        _currentPlayerShip = Instantiate(_playerShips[Random.Range(0, _playerShips.Length)], new Vector2(0,0), Quaternion.identity);
                    }

                    //CameraBehaviour.OnSearchingPlayer?.Invoke();

                    OnNextGameState.Invoke(GamePlayStates.START);

                    break;
                }
            case GamePlayStates.START:
                {

                    OnNextGameState.Invoke(GamePlayStates.GAMEPLAY);

                    break;
                }
            case GamePlayStates.GAMEPLAY:
                {
                    Time.timeScale = 1;

                    PauseGame();

                    break;
                }
            case GamePlayStates.PAUSE:
                {
                    Time.timeScale = 0;

                    PauseGame();

                    break;
                }
            case GamePlayStates.GAMEOVER:
                {
                    Time.timeScale = 0;

                    break;
                }
        }
    }

    public GamePlayStates NextGameStates(GamePlayStates newState)
    {
        _gamePlayPreviousState = _gamePlayCurrentState;
        return _gamePlayNextState = newState;
    }

    public GamePlayStates UpdateState()
    {
        return _gamePlayCurrentState = _gamePlayNextState;
    }

    public GamePlayStates GetCurrentGameState()
    {
        return GamePlayCurrentState;
    }

    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GetCurrentGameState() != GamePlayStates.PAUSE)
            {
                OnNextGameState?.Invoke(GamePlayStates.PAUSE);
            }
            else
            {
                OnNextGameState?.Invoke(GamePlayStates.GAMEPLAY);
            }
        }
    }

    private void OnEnable()
    {
        OnNextGameState += NextGameStates;
    }
    private void OnDisable()
    {
        OnNextGameState -= NextGameStates;
    }
}

