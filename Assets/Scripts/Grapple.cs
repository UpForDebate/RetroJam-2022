using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Grapple : Interactable
{
    GameObject _player;
    [SerializeField]
    float targetSpeed = 20f;
    [SerializeField]
    float grapplePullForce = 1f;
    float currentSpeed = 0f;
    public override void Interact()
    {
        _player = CharacterManager.Instance.ActiveCharacter;
        _player.GetComponent<ThirdPersonController>().Gravity = 0;
        
    }
    private void Update()
    {
        if(_player !=null)
            PullIn();
    }


    void PullIn()
    {
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, grapplePullForce);
        Vector3 direction = transform.position - _player.transform.position;

        _player.transform.position += (direction.normalized * currentSpeed * Time.deltaTime);
        if (direction.magnitude < 0.5)
        {
            currentSpeed = 0f;
            _player.GetComponent<ThirdPersonController>().Gravity = -15;
            _player = null;
        }
    }
}
