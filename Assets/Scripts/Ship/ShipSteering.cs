using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSteering : MonoBehaviour
{
    //rate the ship turns
    public float turnRate = 5.0f;

    //the strength which the ship levels out
    public float levelDamping = 1.0f;

    void Update()
    {
        //user input
        var steeringInput = InputManager.Instance.steering.delta;

        //rotation amount
        var rotation = new Vector2();

        rotation.x = steeringInput.x;
        rotation.y = steeringInput.y;

        rotation *= turnRate;

        rotation.x = Mathf.Clamp(rotation.x, -Mathf.PI * 0.9f, Mathf.PI * 0.9f);

        var newOrientation = Quaternion.Euler(rotation);

        transform.rotation *= newOrientation;

        var levelAngles = transform.eulerAngles;
        levelAngles.z = 0.0f;
        var levelOrientation = Quaternion.Euler(levelAngles);

        transform.rotation = Quaternion.Slerp(transform.rotation, levelOrientation, 
            levelDamping * Time.deltaTime);
    }
}
