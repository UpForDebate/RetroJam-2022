using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class ShadowMode : MonoBehaviour
{
    Light[] levelPointLights;
    //Light[] levelDirectionalLights;
    Light[] levelSpotLights;
    bool inShadowMode = false;
    StarterAssetsInputs _input;
    CharacterController _controller;
    float _speed;
    float _targetRotation = 0.0f;
    private float _rotationVelocity;
    [SerializeField]
    float speedChangeRate = 10.0f;

    [SerializeField]
    float moveSpeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        levelPointLights = Light.GetLights(LightType.Point, 0);
        //levelDirectionalLights = Light.GetLights(LightType.Directional, 0);
        levelSpotLights = Light.GetLights(LightType.Spot, 0);
        _input = GetComponent<StarterAssetsInputs>();
        _controller = GetComponent<CharacterController>();

    }


    void FixedUpdate()
    {
        if (inShadowMode)
        {
            Move();
            if (!CanShadow(transform.position))
            {
                inShadowMode = false;
            }
            

        }
    }
    private void Update()
    {
        bool test = CanShadow(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
        Debug.Log(test);
    }

    bool CanShadow(Vector3 testedPosition)
    {
        if (levelPointLights.Length == 0 && levelSpotLights.Length == 0)
            return false;

        //test each light for a 
        foreach(Light light in levelPointLights)
        {
            if (!PointLightHit(testedPosition, light))
                return false;
        }
        foreach (Light light in levelSpotLights)
        {
            if (!SpotLightHit(testedPosition, light))
                return false;
        }
        return true;
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

        Debug.Log(Mathf.Cos(Mathf.Deg2Rad * light.spotAngle));
        Debug.Log(Vector3.Dot(-direction.normalized, light.transform.forward));
        if (Vector3.Dot(light.transform.forward, -direction.normalized) < Mathf.Cos(Mathf.Deg2Rad*light.spotAngle/2))
            return false;

        if (Physics.Raycast(light.transform.position, direction, direction.magnitude))
            return false;


        return true;
    }
    /*bool DirectionalLightHit()
    {

    }*/

    private void Move()
    {
        // set target speed based on move speed, sprint speed and if sprint is pressed
        float targetSpeed = moveSpeed;

        // a simplistic acceleration and deceleration designed to be easy to remove, replace, or iterate upon

        // note: Vector2's == operator uses approximation so is not floating point error prone, and is cheaper than magnitude
        // if there is no input, set the target speed to 0
        if (_input.move == Vector2.zero) targetSpeed = 0.0f;

        // a reference to the players current horizontal velocity
        float currentHorizontalSpeed = new Vector3(_controller.velocity.x, 0.0f, _controller.velocity.z).magnitude;

        float speedOffset = 0.1f;
        float inputMagnitude = _input.analogMovement ? _input.move.magnitude : 1f;

        // accelerate or decelerate to target speed
        if (currentHorizontalSpeed < targetSpeed - speedOffset || currentHorizontalSpeed > targetSpeed + speedOffset)
        {
            // creates curved result rather than a linear one giving a more organic speed change
            // note T in Lerp is clamped, so we don't need to clamp our speed
            _speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude, Time.deltaTime * speedChangeRate);

            // round speed to 3 decimal places
            _speed = Mathf.Round(_speed * 1000f) / 1000f;
        }
        else
        {
            _speed = targetSpeed;
        }

        // normalise input direction
        Vector3 inputDirection = new Vector3(_input.move.x, 0.0f, _input.move.y).normalized;

        // note: Vector2's != operator uses approximation so is not floating point error prone, and is cheaper than magnitude
        // if there is a move input rotate player when the player is moving
        if (_input.move != Vector2.zero)
        {
            _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity, 0.2f);

            // rotate to face input direction relative to camera position
            transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        }


        Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;

        // move the player
        _controller.Move(targetDirection.normalized * (_speed * Time.deltaTime) * Time.deltaTime);
    }
}
