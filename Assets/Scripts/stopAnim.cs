using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopAnim : MonoBehaviour
{
    Animator m_animator;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision col)
    {
        if(Input.GetButton("indexKey"))
        {
            m_animator.enabled = false;
        }
        
    }
    
}
