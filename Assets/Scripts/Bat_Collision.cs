﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_Collision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("当たったよ");    
    }
}