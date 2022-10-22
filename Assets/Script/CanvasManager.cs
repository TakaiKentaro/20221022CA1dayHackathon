using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] Canvas _startCanvas;
    [SerializeField] Canvas _inGameCanvas;
    [SerializeField] Canvas _gameOverCanvas;

    private void Start()
    {
        _startCanvas.gameObject.SetActive(true);
        _inGameCanvas.gameObject.SetActive(false);
        _gameOverCanvas.gameObject.SetActive(false);
    }

    public void OnClickStart()
    {
        _startCanvas.gameObject.SetActive(false);
        _inGameCanvas.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        _gameOverCanvas.gameObject.SetActive(true);
    }

    public void BackTitle()
    {
        SceneManager.LoadScene("GameScene");
    }
}
