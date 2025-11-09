using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] private GameObject TurnOffAsteroid;
    [SerializeField] private GameObject TurnOnAsteroidExplode;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth.instance.CollidWithAsteroid();
            TurnOffAsteroid.SetActive(false);
            TurnOnAsteroidExplode.SetActive(true);

            Invoke("TurnOffAsteroidExplode", 0.5f);
        }
    }

    void TurnOffAsteroidExplode()
    {
        TurnOnAsteroidExplode.SetActive(false);
    }
}
