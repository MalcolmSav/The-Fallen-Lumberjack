using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    // Start is called before the first frame update

    private Color m_oldColor = Color.white;
   
    private void OnTriggerEnter(Collider other)
    {
        Collider fence = GetComponent<Collider>();
        Renderer render = GetComponent<Renderer>();
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(fence);
            Destroy(render);
        }
        
    }
    
    private void OnTriggerExit(Collider other)
    {
        Renderer render = GetComponent<Renderer>();
        render.material.color = m_oldColor;
    }
}

