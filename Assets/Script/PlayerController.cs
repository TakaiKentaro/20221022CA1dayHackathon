using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CanvasManager _canvasManager;
    [SerializeField] StageCreatManager _stageCreatManager;
    [SerializeField] AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GameObject.Find("GameOverSE").GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            Debug.Log("ゲームオーバー");
            _audioSource.Play();
            gameObject.SetActive(false);
            GameManager.Instance.GameOver();
            _canvasManager.GameOver();
            _stageCreatManager.StopCreat();
        }
    }
}
