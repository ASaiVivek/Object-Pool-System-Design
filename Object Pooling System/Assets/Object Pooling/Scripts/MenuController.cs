using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject MenuPanel;
    Animator anim;

    [HideInInspector]
    public bool started;

    private void Start()
    {
        started = false;
        anim = MenuPanel.GetComponent<Animator>();
    }

    public void SetOnStart()
    {
        started = true;
        anim.SetBool("start", true);
        
    }
}
