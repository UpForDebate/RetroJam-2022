using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toogle : Interactable
{
    [SerializeField]
    GameObject toggle;

    private void Start()
    {
        toggle.SetActive(false);
    }

    public override void Interact()
    {
        toggle.SetActive(!toggle.activeSelf);
    }
}
