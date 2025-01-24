using Audio;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    //class references
    [SerializeField] private PlayerController playerController;
    [SerializeField] private UiManager uiManager;
    [SerializeField] private AudioManager audioManager;
    
    //player progression track
    private GameState _gameState;
    bool isInRhythmicMode;
    
    //rhythm variables
    [SerializeField] private Rhythm[] _rhythms;
    private int _rhythmsIndex;
    [SerializeField]private float _maxTimer;
    private float _timer;
    
    //events 
    public event UnityAction OnRhythmSectionStart;
    public event UnityAction OnRhythmSectionFail;
    public event UnityAction<int> OnRhythmSectionWin;
    public event UnityAction<AudioClip> OnNoteSuccession;
    public event UnityAction OnInputSuccession;
    
    private event UnityAction OnGameWin;

    void OnEnable()
    {
        //event subscriptions
        SubscribeToInputSystem();
    }

    void OnDisable()
    {
        //event unsubscription
        UnsubscribeToInputSystem();
    }

    private void SubscribeToInputSystem()
    {
        playerController.OnUpPressed += CheckInputUp;
        playerController.OnDownPressed += CheckInputDown;
        playerController.OnRightPressed += CheckInputRight;
        playerController.OnLeftPressed += CheckInputLeft;
    }
    private void UnsubscribeToInputSystem()
    {
        playerController.OnUpPressed -= CheckInputUp;
        playerController.OnDownPressed -= CheckInputDown;
        playerController.OnRightPressed -= CheckInputRight;
        playerController.OnLeftPressed -= CheckInputLeft;
    }
    
    private void PlayerPassedRhythm()
    {
        switch (_gameState)
        {
            case GameState.LevelOne:
                OnRhythmSectionWin?.Invoke(0);
                ++_gameState;
                break;
            case GameState.LevelTwo:
                OnRhythmSectionWin?.Invoke(1);
                ++_gameState;
                break;
            case GameState.LevelThree:
                OnRhythmSectionWin?.Invoke(2);
                ++_gameState;
                break;
            case GameState.LevelFour:
                OnRhythmSectionWin?.Invoke(3);
                ++_gameState;
                break;
            case GameState.LevelFive:
                OnRhythmSectionWin?.Invoke(4);
                ++_gameState;
                break;
            case GameState.LevelMax:
                OnGameWin?.Invoke();
                break;
        }

        _rhythmsIndex = 0;
    }
    
    public void CheckInputUp()
    {
        var isMatchingInput = _rhythms[(int)_gameState].IsMatchingInput(ArrowKey.ArrowUp, _rhythmsIndex);
        Debug.Log(isMatchingInput ? "Good!" : "Bad!");
        if (isMatchingInput)
        {
            OnInputSuccession?.Invoke();
        }
        else
        {
            OnRhythmSectionFail?.Invoke();
            return;
        }

        if (_rhythms[(int)_gameState].IsEndOfStep(_rhythmsIndex))
        {
            OnNoteSuccession?.Invoke(_rhythms[(int)_gameState].GetNoteClip(_rhythmsIndex));
            ++_rhythmsIndex;
        }
        
        if (_rhythms[(int)_gameState].IsEndOfRhythm(_rhythmsIndex))
        {
            PlayerPassedRhythm();
        }
    }
    public void CheckInputDown()
    {
        var isMatchingInput = _rhythms[(int)_gameState].IsMatchingInput(ArrowKey.ArrowDown, _rhythmsIndex);
        Debug.Log(isMatchingInput ? "Good!" : "Bad!");
        if (isMatchingInput)
        {
            OnInputSuccession?.Invoke();
        }
        else
        {
            OnRhythmSectionFail?.Invoke();
            return;
        }

        if (_rhythms[(int)_gameState].IsEndOfStep(_rhythmsIndex))
        {
            OnNoteSuccession?.Invoke(_rhythms[(int)_gameState].GetNoteClip(_rhythmsIndex));
        }
        
        if (_rhythms[(int)_gameState].IsEndOfRhythm(_rhythmsIndex))
        {
            PlayerPassedRhythm();
            return;
        }
        ++_rhythmsIndex;
    }
    public void CheckInputRight()
    {
        var isMatchingInput = _rhythms[(int)_gameState].IsMatchingInput(ArrowKey.ArrowRight, _rhythmsIndex);
        Debug.Log(isMatchingInput ? "Good!" : "Bad!");
        if (isMatchingInput)
        {
            OnInputSuccession?.Invoke();
        }
        else
        {
            OnRhythmSectionFail?.Invoke();
            return;
        }

        if (_rhythms[(int)_gameState].IsEndOfStep(_rhythmsIndex))
        {
            OnNoteSuccession?.Invoke(_rhythms[(int)_gameState].GetNoteClip(_rhythmsIndex));
        }
        
        if (_rhythms[(int)_gameState].IsEndOfRhythm(_rhythmsIndex))
        {
            PlayerPassedRhythm();
            return;
        }
        ++_rhythmsIndex;
    }
    public void CheckInputLeft()
    {
        var isMatchingInput = _rhythms[(int)_gameState].IsMatchingInput(ArrowKey.ArrowLeft, _rhythmsIndex);
        Debug.Log(isMatchingInput ? "Good!" : "Bad!");
        if (isMatchingInput)
        {
            OnInputSuccession?.Invoke();
        }
        else
        {
            OnRhythmSectionFail?.Invoke();
            return;
        }

        if (_rhythms[(int)_gameState].IsEndOfStep(_rhythmsIndex))
        {
            OnNoteSuccession?.Invoke(_rhythms[(int)_gameState].GetNoteClip(_rhythmsIndex));
        }
        
        if (_rhythms[(int)_gameState].IsEndOfRhythm(_rhythmsIndex))
        {
            PlayerPassedRhythm();
            return;
        }
        ++_rhythmsIndex;
    }
    

    private enum GameState
    {
        LevelOne,
        LevelTwo,
        LevelThree,
        LevelFour,
        LevelFive,
        LevelMax,
    }
}