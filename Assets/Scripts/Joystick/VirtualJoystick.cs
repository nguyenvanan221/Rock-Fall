using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RectTransform thumb;

    // position when no dragging
    private Vector2 originalPosition;
    private Vector2 originalThumbPosition;

    //distance thumb drag
    public Vector2 delta;

    void Start()
    {
        originalPosition = this.GetComponent<RectTransform>().localPosition;
        originalThumbPosition = thumb.localPosition;

        thumb.gameObject.SetActive(false);

        delta = Vector2.zero;
    }

    // when dragging starts
    public void OnBeginDrag(PointerEventData eventData)
    {
        thumb.gameObject.SetActive(true);

        Vector3 worldPoint = new Vector3();
        RectTransformUtility.ScreenPointToWorldPointInRectangle(this.transform as RectTransform,
            eventData.position, eventData.enterEventCamera, out worldPoint);

        this.GetComponent<RectTransform>().position = worldPoint;
        thumb.localPosition = originalThumbPosition;
    }

    // when drag moves
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 worldPoint = new Vector3();
        RectTransformUtility.ScreenPointToWorldPointInRectangle(this.transform as RectTransform,
            eventData.position, eventData.enterEventCamera, out worldPoint);

        thumb.position = worldPoint;

        //calculate distance from original position
        var size = GetComponent<RectTransform>().rect.size;
        delta = thumb.localPosition;

        delta.x /= size.x / 2.0f;
        delta.y /= size.y / 2.0f;

        delta.x = Mathf.Clamp(delta.x, -1.0f, 1.0f);
        delta.y = Mathf.Clamp(delta.y, -1.0f, 1.0f);

    }

    // when dragging ends
    public void OnEndDrag(PointerEventData eventData)
    {
        //reset position joystick
        this.GetComponent<RectTransform>().localPosition = originalPosition;

        //reset distance
        delta = Vector2.zero;

        thumb.gameObject.SetActive(false);
    }

}
