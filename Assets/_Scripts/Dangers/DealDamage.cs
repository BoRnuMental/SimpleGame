using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public static Action onPlayerDamaged;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.GetComponent<PlayerHealth>()) return;
        onPlayerDamaged?.Invoke();
        Destroy(gameObject);
    }
}
