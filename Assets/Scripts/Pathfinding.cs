using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public List<Transform> positions = new List<Transform>();
    public int currentTarget;
    [SerializeField]
    float speed = 20;

    private void Start()
    {
        transform.position = positions[0].position;
        currentTarget = 1;
    }

    private void Update()
    {
        Vector3 direction = (positions[currentTarget].position - transform.position).normalized;

        transform.position += direction * Time.deltaTime * speed;

        if ((positions[currentTarget].position - transform.position).magnitude < 0.1)
            if (currentTarget < positions.Count - 1)
                currentTarget++;
            else
                currentTarget = 0;

    }
}
