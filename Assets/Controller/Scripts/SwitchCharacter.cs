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
        whiteDude.SetActive(!whiteDude.activeSelf);
        blackDude.SetActive(!blackDude.activeSelf);
    }
}
