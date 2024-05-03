using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 10.0f;

    void Start()
    {
        this.GetComponent<Rigidbody>().velocity = transform.forward * speed;

        var indicator = IndicatorManager.Instance.AddIndicator(gameObject, Color.red);

        indicator.showDistanceTo = GameManager.Instance.CurrentSpaceStation.transform;
    }

    
}
