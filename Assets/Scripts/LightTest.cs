using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTest : MonoBehaviour
{
    public static LightTest Instance { get; private set; }


    Light[] levelPointLights;
    //Light[] levelDirectionalLights;
    Light[] levelSpotLights;
    private void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;


        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        levelPointLights = Light.GetLights(LightType.Point, 0);
        //levelDirectionalLights = Light.GetLights(LightType.Directional, 0);
        levelSpotLights = Light.GetLights(LightType.Spot, 0);

    }
    public bool hasLight(Vector3 testedPosition)
    {
        /*if (levelPointLights.Length == 0 && levelSpotLights.Length == 0)
            return false;
        */
        //test each light for a 
        foreach (Light light in levelPointLights)
        {
            if (PointLightHit(testedPosition, light))
                return true;
        }
        foreach (Light light in levelSpotLights)
        {
            if (SpotLightHit(testedPosition, light))
                return true;
        }
        return false;
    }

    bool PointLightHit(Vector3 target, Light light)
    {
        Vector3 direction = light.transform.position - target;


        if (direction.magnitude > light.range)
            return false;

        if (Physics.Raycast(light.transform.position, direction, direction.magnitude))
            return false;

        return true;
    }
    bool SpotLightHit(Vector3 target, Light light)
    {

        Vector3 direction = light.transform.position - target;


        if (direction.magnitude > light.range)
            return false;

        if (Vector3.Dot(light.transform.forward, -direction.normalized) < Mathf.Cos(Mathf.Deg2Rad * light.spotAngle / 2))
            return false;

        if (Physics.Raycast(light.transform.position, direction, direction.magnitude))
            return false;


        return true;
    }
}
