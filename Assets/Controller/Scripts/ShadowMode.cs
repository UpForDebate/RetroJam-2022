using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMode : MonoBehaviour
{
    Light[] levelPointLights;
    //Light[] levelDirectionalLights;
    Light[] levelSpotLights;
    bool inShadowMode = false;
    // Start is called before the first frame update
    void Start()
    {
        levelPointLights = Light.GetLights(LightType.Point, 0);
        //levelDirectionalLights = Light.GetLights(LightType.Directional, 0);
        levelSpotLights = Light.GetLights(LightType.Spot, 0);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inShadowMode)
        {
            if (!CanShadow(transform))
            {

            }
        }
    }


    bool CanShadow(Transform testedPosition)
    {
        //test each light for a 
        foreach(Light light in levelPointLights)
        {
            
        }
        return true;
    }

    bool PointLightHit(Transform target, Light light)
    {
        Vector3 direction = light.transform.position - target.position;


        if (direction.magnitude > light.range)
            return false;

        if (Physics.Raycast(light.transform.position, direction, direction.magnitude))
            return false;

        return true;
    }
    bool SpotLightHit(Transform target, Light light)
    {

        Vector3 direction = light.transform.position - target.position;


        if (direction.magnitude > light.range)
            return false;

        if (Vector3.Dot(direction.normalized, light.transform.forward) < Mathf.Cos(light.spotAngle))
            return false;

        if (Physics.Raycast(light.transform.position, direction, direction.magnitude))
            return false;


        return true;
    }
    /*bool DirectionalLightHit()
    {

    }*/

}
