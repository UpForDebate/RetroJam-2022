using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{

    GameObject _player, _node;
    float targetSpeed = 20f;
    float currentSpeed = 0f;
    GrapplingHook(GameObject player, GameObject node)
    {
        _player = player;
        _node = node;

    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, 0.2f);
        Vector3 direction = _node.transform.position - _player.transform.position;
        
        _player.GetComponent<CharacterController>().Move(direction.normalized * currentSpeed);
        if (direction.magnitude < 0.2)
        {
            Destroy(this);
        }
    }
}
