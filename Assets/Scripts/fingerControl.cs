using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fingerControl : MonoBehaviour
{
    public GameObject myhand;

    Animator m_animator;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        m_animator.SetBool("IsThungActive", false);
        m_animator.SetBool("IsIndexActive", false);
        m_animator.SetBool("IsMiddleActive", false);
        m_animator.SetBool("IsRingActive", false);
        m_animator.SetBool("IsPinkyActive", false);

        if (Input.GetButton("indexKey"))
        {
            m_animator.Play("Armature|index");
            m_animator.SetBool("IsIndexActive", true);
            
        } 
        if(Input.GetButton("middleKey"))
        {
            m_animator.Play("Armature|middle");
            m_animator.SetBool("IsMiddleActive", true);
        }
        if(Input.GetButton("ringKey"))
        {
            m_animator.Play("Armature|ring");
            m_animator.SetBool("IsRingActive", true);
        } 
        if(Input.GetButton("pinkyKey"))
        {
            m_animator.Play("Armature|pinky");
            m_animator.SetBool("IsPinkyActive", true);
        }
        if(Input.GetButton("thumbKey"))
        {
            m_animator.Play("Armature|thung");
            m_animator.SetBool("IsThungActive", true);
        }

        if (Input.GetButton("fistKey"))
        {
            m_animator.Play("Armature|thung");
            m_animator.SetBool("IsThungActive", true);
            m_animator.Play("Armature|pinky");
            m_animator.SetBool("IsPinkyActive", true);
            m_animator.Play("Armature|ring");
            m_animator.SetBool("IsRingActive", true);
            m_animator.Play("Armature|middle");
            m_animator.SetBool("IsMiddleActive", true);
            m_animator.Play("Armature|index");
            m_animator.SetBool("IsIndexActive", true);
        }

    }
}

