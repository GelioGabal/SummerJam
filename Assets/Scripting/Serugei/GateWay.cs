using System;
using UnityEngine;
using UnityEngine.Events;

public class GateWay : InteractiveObject
{
    public bool isOpen {  get; private set; }
    Collider2D coll;
    Animator anim;
    private void Start()
    {
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        base.OnInteract.AddListener(Interact);
    }
    void Interact()
    {
        isOpen = !isOpen;
        coll.enabled = !isOpen;
        if(anim != null)
            anim.SetBool("IsOpen", isOpen);
    }
}
