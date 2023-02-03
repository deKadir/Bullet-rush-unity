
using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenTouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

    private Vector2 _touchPosition;
    public Vector2 Direction { get; private set; }

    public void OnDrag(PointerEventData eventData)
    {
        var delta = eventData.position - _touchPosition;
        Direction = delta.normalized;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        _touchPosition = eventData.position;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        Direction = Vector3.zero;
    }
}