
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

public class GameBehaviour : GamePlayBehaviour
{

 public delegate GamePlayStates _onNextGameState(GamePlayStates gameStates);
        public static _onNextGameState OnNextGameState;

        [UnityEngine.SerializeField] GamePlayStates _gamePlayPreviousState;
        [UnityEngine.SerializeField] GamePlayStates _gamePlayCurrentState;
        [UnityEngine.SerializeField] GamePlayStates _gamePlayNextState;

        public GamePlayStates GamePlayPreviousState
        { get { return _gamePlayPreviousState; } }

        public GamePlayStates GamePlayCurrentState
        { get { return _gamePlayCurrentState; } }

        public GamePlayStates GamePlayNextState
        { get { return _gamePlayNextState; } }

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
        switch(state)
        {
            case GamePlayStates.INITIALIZING:
                {
                    //CameraBehaviour.OnSearchingPlayer?.Invoke();

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
            return _gamePlayCurrentState = _gamePlayNextState ;
        }
        
        public GamePlayStates GetCurrentGameState()
        {
            return GamePlayCurrentState;
        }

    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GetCurrentGameState() != GamePlayStates.PAUSE)
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
