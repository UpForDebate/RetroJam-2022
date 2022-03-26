using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    [SerializeField]
    private GameObject Character;
    [SerializeField]
    private float speed = 1;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, Character.transform.position.x, Time.deltaTime * speed),
            Mathf.Lerp(transform.position.y, Character.transform.position.y + 1.3f, Time.deltaTime * speed),
            Mathf.Lerp(transform.position.z, Character.transform.position.z, Time.deltaTime * speed)
            );
    }
}
