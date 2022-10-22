using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreatManager : MonoBehaviour
{
    [SerializeField] GameObject[] _stages;
    [SerializeField] float _creatTime = 1;

    Vector3 vec3;

    public void StartCreat()
    {
        StartCoroutine(nameof(CreatStage));
    }

    public void StopCreat()
    {
        StopCoroutine(nameof(CreatStage));
    }

    IEnumerator CreatStage()
    {
        while (true)
        {
            int rnd = Random.Range(0, _stages.Length);
            Instantiate(_stages[rnd], vec3, Quaternion.identity);
            yield return new WaitForSeconds(_creatTime);
        }
    }
}
