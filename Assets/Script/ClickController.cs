using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{
    [SerializeField] int _clickDmg = 1;

    [SerializeField] string _blockTag = "";

    private void Update()
    {
        OnClickBlock();
    }

    void OnClickBlock()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray();
            RaycastHit hit = new RaycastHit();
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.CompareTag(_blockTag))
                {
                    var obj = hit.collider.gameObject.GetComponent<BlockController>();
                    //obj.OnDamageBlock(_clickDmg);
                }
            }
        }
    }
}
