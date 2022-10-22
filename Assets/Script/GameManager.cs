using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    Title,
    InGame,
    GameOver,
}

public class GameManager : MonoBehaviour
{
    static public GameManager _instance = null;
    public static GameManager Instance => _instance;

    [SerializeField] GameState _gameState = GameState.Title;

    [SerializeField] Text _powerText;

    public static int GameScore;
    public static int _power = 1;
    public static int _powerUpLimit = 10;

    public GameState GameState
    {
        get => _gameState;
    }

    private void Awake()
    {
        if (!_instance)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        _powerText.text = $"ÇœÇÌÅ[{_power}";
    }

    public void GameStart()
    {
        _gameState = GameState.InGame;
    }

    public void GameOver()
    {
        _gameState = GameState.GameOver;
    }

    public void OnClickPowerUp()
    {
        if(GameScore >= _powerUpLimit)
        {
            GameScore -= _powerUpLimit;
            _powerUpLimit += 10;
            _power++;
            _powerText.text = $"ÇœÇÌÅ[{_power}";
        }
    }

}
