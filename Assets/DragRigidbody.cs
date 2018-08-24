using UnityEngine;
using System.Collections;

public class DragRigidbody : MonoBehaviour
{

    public float catchingDistance = 5f;
    bool isDragging = false;
    GameObject draggingObject;
    bool kinematic;
    int saveLayer;
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))//клик левой мышью
        {
            if (!isDragging)
            {
                draggingObject = GetObjectFromMouseRaycast();//мы получили объект, в который попал луч из камеры через курсор    
                if (draggingObject)
                {
                    kinematic = draggingObject.GetComponent<Rigidbody>().isKinematic;
                    draggingObject.GetComponent<Rigidbody>().isKinematic = true; //это нужно, чтобы поднятый объект не падал, пока его держат
                    saveLayer = draggingObject.layer;
                    if (draggingObject.layer != 0) draggingObject.layer = 8;
                    isDragging = true;
                }
            }
            else if (draggingObject != null && !kinematic)
            {
                draggingObject.GetComponent<Rigidbody>().MovePosition(CalculateMouse3DVector());
            }
        }
        else
        {
            if (draggingObject != null)
            {
                draggingObject.GetComponent<Rigidbody>().isKinematic = kinematic;
                draggingObject.layer = saveLayer;
            }
            isDragging = false;
        }
    }
    private GameObject GetObjectFromMouseRaycast()
    {
        GameObject gmObj = null;
        RaycastHit hitInfo = new RaycastHit();
        //mousePosition x,y курсора на экране
        //Raycast кастует луч, возвращает тру, если луч пересекся с коллайдером
        //Camera.main.ScreenPointToRay(Input.mousePosition) возвращает луч, который идет из камеры через курсор (начальная точка и направление луча)
        //hitInfo содержит какую-то информацию о месте, куда попал луч
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
        if (hit)//если попало в коллайдер
        {
            if (hitInfo.collider.gameObject.GetComponent<Rigidbody>() &&
                Vector3.Distance(hitInfo.collider.gameObject.transform.position,
                transform.position) <= catchingDistance)
            {
                gmObj = hitInfo.collider.gameObject;
            }
        }
        return gmObj;
    }
    private Vector3 CalculateMouse3DVector()
    {
        Vector3 v3 = Input.mousePosition;
        v3.z = 1f;
        v3 = Camera.main.ScreenToWorldPoint(v3);
        //Debug.Log(v3); //Current Position of mouse in world space
        return v3;
    }
}