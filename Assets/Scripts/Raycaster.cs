using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    float m_maxDistance = 100f;
    int m_layerMask = 0;

    private void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawLine(ray.origin, ray.direction * m_maxDistance, Color.red);
        int layerMask = 1 << 5;
        if (Physics.Raycast(transform.position, transform.forward, out hit, m_maxDistance, layerMask))
        {
            Debug.Log("Did Hit" + hit.collider.gameObject.name);   
        }
        else
        {
            Debug.Log("Did not hit");
        }
    }
}
