using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum States
    {
        MENU,
        PLAYING,
        RESET_POSITION,
        END_GAME
    }

    public Dictionary<States, StateBase> dictionaryState;
    private StateBase _currentState;
    //public Player player;
    public float TimeToStartGame = 1f;

    public static StateMachine Instance;

    private void Awake()
    {
        Instance = this;

        dictionaryState = new Dictionary<States, StateBase>();
        dictionaryState.Add(States.MENU, new StateBase());
        dictionaryState.Add(States.PLAYING, new statePlaying());
        dictionaryState.Add(States.RESET_POSITION, new stateResetPosition());
        dictionaryState.Add(States.END_GAME, new stateEndGame());

        SwitchState(States.MENU);
    }

    public void SwitchState(States state)
    {
        if (_currentState != null) _currentState.onStateExit();

        _currentState = dictionaryState[state];

        if (_currentState != null) _currentState.onStateEnter();
        
        //_currentState.onStateEnter(player);

    }

    private void Update()
    {
        if (_currentState != null) _currentState.onStateStay();
                  
    }

    public void ResetPosition()
    {
        SwitchState(States.RESET_POSITION);
    }
}
