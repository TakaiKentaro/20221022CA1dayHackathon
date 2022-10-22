using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TimeManager _timeManager;
    [SerializeField] Text _titleText;
    [SerializeField] Text _inGameText;

    bool _check;
    public int _gameScore;

    private void Start()
    {
        _inGameText.text = $"‚·‚±‚ :{_gameScore.ToString("D7")}";
    }

    void Update()
    {
        switch (GameManager.Instance.GameState)
        {
            case GameState.Title:
                _titleText.text = GameManager.GameScore.ToString();
                break;
            case GameState.InGame:
                InGame();
                break;
            case GameState.GameOver:
                GameManager.GameScore += _gameScore;
                _gameScore = 0;
                break;
        }
    }

    void InGame()
    {
        if(!_check)
        {
            StartCoroutine(nameof(ScoreUp));
            _check = true;
        }
        
    }

    IEnumerator ScoreUp()
    {
        while(GameManager.Instance.GameState == GameState.InGame)
        {
            yield return new WaitForSeconds(1f);
            _gameScore += 1;
            _inGameText.text = $"‚·‚±‚ :{_gameScore.ToString("D7")}";
        }
    }

    public void ScoreGet(int score)
    {
        _gameScore += score;
        _inGameText.text = $"‚·‚±‚ :{_gameScore.ToString("D7")}";
    }
}
