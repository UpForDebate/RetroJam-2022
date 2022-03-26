using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Deadly : MonoBehaviour
{
    public bool Destroyable = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ThirdPersonController>(out ThirdPersonController tps))
        {
            tps.Die();
        }

        if (Destroyable)
        {
            Destroy(gameObject);
        }
    }
}
