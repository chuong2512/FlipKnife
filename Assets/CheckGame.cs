using System;
using System.Collections;
using System.Collections.Generic;
using ChuongCustom;
using UnityEngine;

public class CheckGame : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"tag : {collision.gameObject.tag}");
        
        if (Manager.InGame.State != StateGame.Lose)
        {
            Knife.Instance.Check();
        }
    }

    private void OnCollision2DEnter(Collision collision)
    {
      
    }
}