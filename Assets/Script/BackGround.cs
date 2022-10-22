using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] float _scrollSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(Time.deltaTime + _scrollSpeed, 0);

        if(transform.position.x <= -19.2f)
        {
            transform.position = new Vector2(19.2f, 0);
        }
    }
}
