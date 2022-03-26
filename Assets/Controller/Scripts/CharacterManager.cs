using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    #region Singleton
    private static CharacterManager _instance;
    public static CharacterManager Instance 
    {
        get 
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<CharacterManager>();
            }

            return _instance;
        }
    }
    #endregion

    [SerializeField]
    private GameObject LightCharacter;
    [SerializeField]
    private GameObject ShadowCharacter;

    public void SwitchCharacter() 
    {

    }
}
