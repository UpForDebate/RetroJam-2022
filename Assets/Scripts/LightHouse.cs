using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHouse : Interactable
{
    [SerializeField]
    bool isLight = true;
    [SerializeField]
    GameObject light;

    private void Start()
    {
        light.SetActive(false);
    }

    private void Update()
    {
        light.transform.Rotate(0, 10 * Time.deltaTime, 0);
    }

    public override void Interact()
    {
        if (CharacterManager.Instance.ShadowActive && isLight 
            || !CharacterManager.Instance.ShadowActive && !isLight)
        {
            return;
        }
        else
        {
            light.SetActive(true);
        }
    }
}   
