using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    //class references
    [SerializeField] private PlayerController playerController;
    [SerializeField] private UiManager uiManager;
    
    //player progression track
    private GameState _gameState;
    
    //rhythm variables
    [SerializeField] private Rhythm[] _rhythms;
    private int _rhythmsIndex;
    [SerializeField]private float _maxTimer;
    private float _timer;
    
    //events 
    private event UnityAction OnRhythmSectionStart;
    private event UnityAction OnRhythmSectionEnd;

    void OnEnable()
    {
        //event subscriptions
        playerController.OnUpPressed += CheckInputUp;
        playerController.OnDownPressed += CheckInputDown;
        playerController.OnRightPressed += CheckInputRight;
        playerController.OnLeftPressed += CheckInputLeft;
    }
    
    void start()
    {
        _gameState = GameState.LevelOne;
    }

    void OnDisable()
    {
        //event unsubscription
    }

    private void PlayerPassedRhythm()
    {
        _gameState++;
        if (_gameState == GameState.LevelMax)
        {
            //invoke end of game
        }
        else
        {
            //invoke next level 
        }
    }
    
    public void InvokeOnRhythmSectionStart()
    {
        OnRhythmSectionStart?.Invoke();
    }
    public void InvokeOnRhythmSectionEnd()
    {
        OnRhythmSectionEnd?.Invoke();
    }

    public void CheckInputUp()
    {
        var isMatchingInput = _rhythms[(int)_gameState].IsMatchingInput(ArrowKey.ArrowUp, _rhythmsIndex);
        Debug.Log(isMatchingInput ? "Good!" : "Bad!");

        if (!_rhythms[(int)_gameState].IsEndOfStep(_rhythmsIndex)) return;
        
        if (_rhythms[(int)_gameState].IsEndOfRhythm(_rhythmsIndex))
        {
            PlayerPassedRhythm();
            return;
        }
        ++_rhythmsIndex;
    }
    
    public void CheckInputDown()
    {
        var isMatchingInput = _rhythms[(int)_gameState].IsMatchingInput(ArrowKey.ArrowDown, _rhythmsIndex);
        Debug.Log(isMatchingInput ? "Good!" : "Bad!");

        if (_rhythms[(int)_gameState].IsEndOfStep(_rhythmsIndex))
        {
            ++_rhythmsIndex;
        }
    }
    
    public void CheckInputRight()
    {
        var isMatchingInput = _rhythms[(int)_gameState].IsMatchingInput(ArrowKey.ArrowRight, _rhythmsIndex);
        Debug.Log(isMatchingInput ? "Good!" : "Bad!");

        if (_rhythms[(int)_gameState].IsEndOfStep(_rhythmsIndex))
        {
            ++_rhythmsIndex;
        }
    }
    
    public void CheckInputLeft()
    {
        var isMatchingInput = _rhythms[(int)_gameState].IsMatchingInput(ArrowKey.ArrowLeft, _rhythmsIndex);
        Debug.Log(isMatchingInput ? "Good!" : "Bad!");

        if (_rhythms[(int)_gameState].IsEndOfStep(_rhythmsIndex))
        {
            ++_rhythmsIndex;
        }
    }

    private enum GameState
    {
        LevelOne,
        LevelTwo,
        LevelThree,
        LevelFour,
        LevelMax,
    }
}