using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StageMoveController : MonoBehaviour
{
    [SerializeField] float _moveTime;

    private void Awake()
    {
        gameObject.transform.position = new Vector2(20, 0);
        StageMove();
    }

    public void StageMove()
    {
        transform.DOMove(
            new Vector2(-40, 0),
            _moveTime
         ).OnComplete(
            () => Destroy(this.gameObject)
            );
    }
}
