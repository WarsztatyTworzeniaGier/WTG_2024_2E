using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public Action OnHit;

    [SerializeField]
    private string damagingTag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag(damagingTag))
        {
            Debug.Log("tag is ok " + collision.gameObject.name);

            OnHit?.Invoke();
        }
        
    }
}
