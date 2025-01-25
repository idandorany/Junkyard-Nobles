using System.Collections.Generic;
using Audio;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    //class references
    [Header("Managers & Player")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private UiManager uiManager;
    [SerializeField] private AudioManager audioManager;
    
    [Header("Triggers")]
    [SerializeField] private TriggerEnter triggerEnter;
    [SerializeField] private TriggerExitLose triggerExitLose;
    
    //player progression track
    private GameState _gameState;
    
    //rhythm variables
    [SerializeField] private Rhythm[] rhythms;
    private int _rhythmsIndex;
    [SerializeField] private float maxTimer;
    private float _timer;
    private ArrowKey _triggeredArrow = ArrowKey.ArrowNone;
    private Queue<ArrowTrigger> _arrows = new Queue<ArrowTrigger>();
    
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
        triggerExitLose.LoseEvent += TriggerLose;
    }

    void OnDisable()
    {
        //event unsubscription
        UnsubscribeToInputSystem();
        triggerExitLose.LoseEvent -= TriggerLose;
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
        var arrow = ArrowKey.ArrowUp;
        if(_arrows.Count > 0)
            _triggeredArrow = _arrows.Peek().GetArrowKey();
        var isMatchingInput = rhythms[(int)_gameState].IsMatchingInput(arrow, _rhythmsIndex)
                              && arrow == _triggeredArrow;
        
        Debug.Log(isMatchingInput ? "Good!" : "Bad!");
        if (isMatchingInput)
        {
            OnInputSuccession?.Invoke();
            var arrowTrigger = _arrows.Dequeue();
            arrowTrigger.PlayParticleEffect();
            Destroy(arrowTrigger.gameObject);
        }
        else
        {
            OnRhythmSectionFail?.Invoke();
            return;
        }

        if (rhythms[(int)_gameState].IsEndOfStep(_rhythmsIndex))
        {
            OnNoteSuccession?.Invoke(rhythms[(int)_gameState].GetNoteClip(_rhythmsIndex));
            ++_rhythmsIndex;
        }
        
        if (rhythms[(int)_gameState].IsEndOfRhythm(_rhythmsIndex))
        {
            PlayerPassedRhythm();
        }
    }
    public void CheckInputDown()
    {
        var arrow = ArrowKey.ArrowDown;
        if(_arrows.Count > 0)
            _triggeredArrow = _arrows.Peek().GetArrowKey();
        var isMatchingInput = rhythms[(int)_gameState].IsMatchingInput(arrow, _rhythmsIndex)
                              && arrow == _triggeredArrow;
        
        if (isMatchingInput)
        {
            OnInputSuccession?.Invoke();
            var arrowTrigger = _arrows.Dequeue();
            arrowTrigger.PlayParticleEffect();
            Destroy(arrowTrigger.gameObject);
        }
        else
        {
            OnRhythmSectionFail?.Invoke();
            return;
        }

        if (rhythms[(int)_gameState].IsEndOfStep(_rhythmsIndex))
        {
            OnNoteSuccession?.Invoke(rhythms[(int)_gameState].GetNoteClip(_rhythmsIndex));
            ++_rhythmsIndex;
        }
        
        if (rhythms[(int)_gameState].IsEndOfRhythm(_rhythmsIndex))
        {
            PlayerPassedRhythm();
        }
    }
    public void CheckInputRight()
    {
        var arrow = ArrowKey.ArrowRight;
        if(_arrows.Count > 0)
            _triggeredArrow = _arrows.Peek().GetArrowKey();
        var isMatchingInput = rhythms[(int)_gameState].IsMatchingInput(arrow, _rhythmsIndex)
                              && arrow == _triggeredArrow;
        Debug.Log(_triggeredArrow);
        Debug.Log(isMatchingInput ? "Good!" : "Bad!");
        if (isMatchingInput)
        {
            OnInputSuccession?.Invoke();
            var arrowTrigger = _arrows.Dequeue();
            arrowTrigger.PlayParticleEffect();
            Destroy(arrowTrigger.gameObject);
        }
        else
        {
            OnRhythmSectionFail?.Invoke();
            return;
        }

        if (rhythms[(int)_gameState].IsEndOfStep(_rhythmsIndex))
        {
            OnNoteSuccession?.Invoke(rhythms[(int)_gameState].GetNoteClip(_rhythmsIndex));
            ++_rhythmsIndex;
        }
        
        if (rhythms[(int)_gameState].IsEndOfRhythm(_rhythmsIndex))
        {
            PlayerPassedRhythm();
        }
    }
    public void CheckInputLeft()
    {
        var arrow = ArrowKey.ArrowLeft;
        if(_arrows.Count > 0)
            _triggeredArrow = _arrows.Peek().GetArrowKey();
        var isMatchingInput = rhythms[(int)_gameState].IsMatchingInput(arrow, _rhythmsIndex)
                              && arrow == _triggeredArrow;
        Debug.Log(_triggeredArrow);
        Debug.Log(isMatchingInput ? "Good!" : "Bad!");
        if (isMatchingInput)
        {
            OnInputSuccession?.Invoke();
            var arrowTrigger = _arrows.Dequeue();
            arrowTrigger.PlayParticleEffect();
            Destroy(arrowTrigger.gameObject);
        }
        else
        {
            OnRhythmSectionFail?.Invoke();
            return;
        }

        if (rhythms[(int)_gameState].IsEndOfStep(_rhythmsIndex))
        {
            OnNoteSuccession?.Invoke(rhythms[(int)_gameState].GetNoteClip(_rhythmsIndex));
            ++_rhythmsIndex;
        }
        
        if (rhythms[(int)_gameState].IsEndOfRhythm(_rhythmsIndex))
        {
            PlayerPassedRhythm();
        }
    }

    public void AddToQueue(ArrowTrigger arrowTrigger)
    {
        if(arrowTrigger)
            _arrows.Enqueue(arrowTrigger);
    }

    public void TriggerLose()
    {
        OnRhythmSectionFail?.Invoke();
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