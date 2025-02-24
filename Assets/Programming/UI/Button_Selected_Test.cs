using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Button_Selected_Test : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{

    public RectTransform arrow;
    public float distance = .67f;
    RectTransform current_rect_transform;

    private void Start()
    {
        current_rect_transform = GetComponent<RectTransform>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        arrow.position = new Vector3(current_rect_transform.position.x * distance, 
            current_rect_transform.position.y, 
            current_rect_transform.position.z);
    }
    public void OnSelect(BaseEventData eventData)
    {
        arrow.position = new Vector3(current_rect_transform.position.x * distance,
            current_rect_transform.position.y,
            current_rect_transform.position.z); ;
    }
}
