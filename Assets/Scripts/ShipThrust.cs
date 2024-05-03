using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipThrust : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        var offset = speed * Time.deltaTime * Vector3.forward;
        this.transform.Translate(offset);
    }
}
