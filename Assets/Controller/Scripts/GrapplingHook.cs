using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook
{

    GameObject _player, _node;
    float targetSpeed = 20f;
    float currentSpeed = 0f;
    public GrapplingHook(GameObject player, GameObject node)
    {
        _player = player;
        _node = node;

    }

}
