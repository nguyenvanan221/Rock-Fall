using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    public Transform target;

    public Transform showDistanceTo;

    //label show distance
    public Text distanceLabel;

    public int margin = 50;

    public Color color
    {
        set
        {
            GetComponent<Image>().color = value;
        }
        get { return GetComponent<Image>().color; }
    }

    void Start()
    {
        distanceLabel.enabled = false;        

        this.GetComponent<Image>().enabled = false;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }    

        if (showDistanceTo != null)
        {
            distanceLabel.enabled = true;

            var distance = (int) Vector3.Magnitude(showDistanceTo.position - target.position);
            distanceLabel.text = distance.ToString() + "M";
        }
        else
        {
            distanceLabel.enabled = false;
        }

        GetComponent<Image>().enabled = true;

        var viewPortPoint = Camera.main.WorldToViewportPoint(target.position);

        //behind
        if (viewPortPoint.z <0)
        {
            viewPortPoint.z = 0;
            viewPortPoint = viewPortPoint.normalized;
            viewPortPoint.x *= -Mathf.Infinity;
        }

        var screenPoint = Camera.main.ViewportToScreenPoint(viewPortPoint);
        screenPoint.x = Mathf.Clamp(screenPoint.x, margin, Screen.width - margin*2);
        screenPoint.y = Mathf.Clamp(screenPoint.y, margin, Screen.height - margin * 2);

        var localPosition = new Vector2();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(),
            screenPoint, Camera.main, out localPosition);

        var rectTranform = GetComponent<RectTransform>();
        rectTranform.localPosition = localPosition;
    }
}
