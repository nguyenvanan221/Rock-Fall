using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public Vector3 offset = new Vector3(0, 1, -10);

    void Update()
    {
        if (!target)
        {
            return;
        }

        transform.position = target.position + offset;
        //change rotation to face target
        transform.LookAt(target.position);

    }

    //public GameObject target;

    //public float damping = 1.0f;

    //public Vector3 offset;

    //private void Start()
    //{
    //    offset = target.transform.position - transform.position;
    //}

    //void LateUpdate()
    //{
    //    float currentAngle = transform.eulerAngles.y;
    //    float desiredAngle = target.transform.eulerAngles.y;

    //    float angle = Mathf.LerpAngle(currentAngle, desiredAngle, damping * Time.deltaTime);

    //    var rotation = Quaternion.Euler(0, angle, 0);

    //    Vector3 newPos = target.transform.position - (rotation * offset);
    //    transform.position = Vector3.Lerp(transform.position, newPos, damping * Time.deltaTime);

    //    transform.LookAt(target.transform);
    //}
}
