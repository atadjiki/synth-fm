﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public Animation Pickup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Pickup.Play("Static");
    }
}
