using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GateWay : InteractiveObject
{
    public bool isOpen {  get; private set; } = false;
    Collider2D coll;
    Animator anim;
    private void Awake()
    {
        base.OnInteract.AddListener(Interact);
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }
    void Interact()
    {
        isOpen = !isOpen;
        coll.enabled = !isOpen;
        if (anim != null)
            anim.SetBool("IsOpen", isOpen);
    }
}
