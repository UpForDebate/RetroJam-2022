using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

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
    private CinemachineVirtualCamera vCam;
    [SerializeField]
    private GameObject LightCharacter;
    [SerializeField]
    private GameObject ShadowCharacter;
    public GameObject ActiveCharacter { get
        {
            if (LightCharacter.activeSelf)
                return LightCharacter;
            return ShadowCharacter;
        }}
    public bool ShadowActive
    {
        get
        {
            if (LightCharacter.activeSelf)
                return false;
            return true;
        }
    }
    public GameObject UnactiveCharacter
    {
        get
        {
            if (LightCharacter.activeSelf)
                return ShadowCharacter;
            return LightCharacter;
        }
    }


    public void OnDeath() 
    {
        if (LightCharacter.activeSelf)
        {
            LightCharacter.SetActive(false);
            ShadowCharacter.SetActive(true);
            vCam.Follow = ShadowCharacter.transform.Find("PlayerCameraRoot").transform;
        }
        else 
        {
            ShadowCharacter.SetActive(false);
            LightCharacter.SetActive(true);
            vCam.Follow = LightCharacter.transform.Find("PlayerCameraRoot").transform;
        }
    }
}
