using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStation : MonoBehaviour
{

    void Start()
    {
        IndicatorManager.Instance.AddIndicator(gameObject, Color.green);
    }

}
