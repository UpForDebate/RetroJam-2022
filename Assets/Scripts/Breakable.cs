using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : Interactable
{
    public override void Interact()
    {
        Pathfinding temp = gameObject.GetComponent<Pathfinding>();
        transform.position = 
            temp.positions[temp.currentTarget == 0 ? temp.positions.Count - 1 : temp.currentTarget -1].position;
    }
}
