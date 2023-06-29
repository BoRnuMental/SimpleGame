using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpikedBall : MonoBehaviour
{
    [SerializeField] private float _deathDelay;
    private void OnEnable()
    {
        StartCoroutine(DeathDelay(_deathDelay));
    }
    IEnumerator DeathDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
