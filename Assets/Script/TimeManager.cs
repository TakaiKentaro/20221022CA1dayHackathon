using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public int _timer = 0;

    bool _check = false;

    

    void Update()
    {
        InGame();
    }

    void InGame()
    {
        if (GameManager.Instance.GameState == GameState.InGame)
        {
            if(!_check)
            {
                StartCoroutine(nameof(CountTime));
                _check = true;
            }
        }
    }

    IEnumerator CountTime()
    {
        while(GameManager.Instance.GameState == GameState.InGame)
        {
            yield return new WaitForSeconds(1f);
            _timer++;
        }  
    }
}
