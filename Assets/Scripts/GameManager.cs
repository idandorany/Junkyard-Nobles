using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.EventSystems;
using System;

public class GameManager : MonoBehaviour
{
    //class references
    [SerializeField] private PlayerController playerController;
    [SerializeField] private UiManager uiManager;
    
    //player progression track
    private GameState _gameState;
    
    //rhythm variables
    [SerializeField] private GameObject[] _rhythms;
    private int _rhythmsIndex = 0;
    [SerializeField]private float _maxTimer;
    private float _timer;
    
    //events 
    private event Action OnRhythmSectionStart;
    private event Action OnRhythmSectionEnd;

    void OnEnable()
    {
        //event subscriptions
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

    private enum GameState
    {
        LevelOne,
        LevelTwo,
        LevelThree,
        LevelFour,
        LevelMax,
    }
}