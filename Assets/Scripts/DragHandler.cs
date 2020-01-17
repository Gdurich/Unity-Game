using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    GameObject GameField;
    public Vector3 startPosition { get; private set; }
    public bool IsDecided = true;

    void Start()
    {
        startPosition = transform.position;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {

        GameField = GameObject.Find("GameField");
        if (transform.rotation.z != 0) IsDecided = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursor.z = 0;
        if (IsDecided)
        {
            transform.position = cursor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float distance1 = System.Math.Abs(GameField.transform.GetChild(0).transform.position.x - transform.position.x),
            distance2 = System.Math.Abs(GameField.transform.GetChild(1).transform.position.x - transform.position.x),
            distance3 = System.Math.Abs(GameField.transform.GetChild(2).transform.position.x - transform.position.x);
        if (transform.localPosition.x > -480 &&
            transform.localPosition.y > -892 &&
            transform.localPosition.x < 449 &&
            transform.localPosition.y < -663)
        {
            GetComponent<GoblinScript>().isRuning = true;
            transform.parent = GameField.transform;
            if (distance1 < distance2 && distance1 < distance3)
                transform.position = new Vector3(GameField.transform.GetChild(0).transform.position.x, transform.position.y, transform.position.z);
            if (distance2 < distance1 && distance2 < distance3)
                transform.position = new Vector3(GameField.transform.GetChild(1).transform.position.x, transform.position.y, transform.position.z);
            if (distance3 < distance1 && distance3 < distance2)
                transform.position = new Vector3(GameField.transform.GetChild(2).transform.position.x, transform.position.y, transform.position.z);
            IsDecided = false;
            transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
        }
        else
        {
            transform.position = startPosition;
        }       
    }
}
