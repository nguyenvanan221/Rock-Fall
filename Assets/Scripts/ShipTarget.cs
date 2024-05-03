using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTarget : MonoBehaviour
{
    public Sprite targetImage;

    void Start()
    {
        IndicatorManager.Instance.AddIndicator(gameObject, Color.yellow, targetImage);
    }

}
