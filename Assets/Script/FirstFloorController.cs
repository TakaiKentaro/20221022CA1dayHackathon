using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFloorController : MonoBehaviour
{
    [SerializeField] float _destroyTime = 1f;

    public void StartDestroy()
    {
        StartCoroutine(nameof(DestroyTime));
    }

    IEnumerator DestroyTime()
    {
        yield return new WaitForSeconds(_destroyTime);
        gameObject.SetActive(false);
    }
}
