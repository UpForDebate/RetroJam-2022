using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class SwitchCharacter : MonoBehaviour
{
    [SerializeField]
    GameObject whiteDude, blackDude;
    void OnDeath()
    {
        if (whiteDude.activeSelf)
        {
            whiteDude.SetActive(false);
            blackDude.SetActive(true);
        }
        else
        {
            
            blackDude.SetActive(false);
            whiteDude.SetActive(true);
        }
        
    }
}
