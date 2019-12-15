
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;

public class ClickOnModels : MonoBehaviour
{
    GameObject LastSelectedObject = null;
    GameObject MovingObject  = null;
    GameObject RotatingObject = null;
    float oldX;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        int selected = GameObject.Find("InteractionScript").GetComponent<ButtonSelected>().seleted;
        if (selected == 101)//移动
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit) && !IsPointerOverGameObject(Input.mousePosition))
                {
                    Debug.DrawLine(ray.origin, hit.point);
                    GameObject Target = hit.collider.gameObject;
                    if (Target.transform.parent && Target.transform.parent.tag == "R1")
                    {
                        Target.AddComponent<Outline>();
                        Target.GetComponent<Outline>().OutlineWidth = 4;
                        //Target.GetComponent<Outline>().OutlineColor = new Color(0.745283f, 0.1265575f, 0.1265575f, 1);
                        Target.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineAll;
                        MovingObject = Target;

                    }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                Destroy(MovingObject.GetComponent<Outline>());
                MovingObject = null;
            }
            if (Input.GetMouseButton(0))
            {
                if(MovingObject)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, 30.0f, LayerMask.GetMask("Surface")))
                    {
                        MovingObject.transform.parent.transform.position = new Vector3(hit.point.x,
                                                       hit.point.y,
                                                       hit.point.z);
                    }
                }
            }

        }
        else if (selected == 102)//旋转
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit) && !IsPointerOverGameObject(Input.mousePosition))
                {
                    Debug.DrawLine(ray.origin, hit.point);
                    GameObject Target = hit.collider.gameObject;
                    if (Target.transform.parent && Target.transform.parent.tag == "R1")
                    {
                        Target.AddComponent<Outline>();
                        Target.GetComponent<Outline>().OutlineWidth = 4;
                        //Target.GetComponent<Outline>().OutlineColor = new Color(0.745283f, 0.1265575f, 0.1265575f, 1);
                        Target.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineAll;
                        RotatingObject = Target;
                        Debug.Log("1   " + Input.touchCount);
                        oldX = Input.mousePosition.x;

                    }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                Destroy(RotatingObject.GetComponent<Outline>());
                RotatingObject = null;
            }
            if (Input.GetMouseButton(0))
            {
                if (RotatingObject)
                {

                    float X = Input.mousePosition.x;
                    RotatingObject.transform.parent.gameObject.transform.Rotate(new Vector3(0, 0.1f, 0) * (oldX - X));


                    oldX = Input.mousePosition.x;

                }
            }

        }
        else if (selected == 103)//删除
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit) && !IsPointerOverGameObject(Input.mousePosition))
                {
                    Debug.DrawLine(ray.origin, hit.point);
                    GameObject Target = hit.collider.gameObject;
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit) && !IsPointerOverGameObject(Input.mousePosition))
                {
                    Debug.DrawLine(ray.origin, hit.point);
                    GameObject Target = hit.collider.gameObject;
                    if (Target.transform.parent && Target.transform.parent.tag == "R1")
                    {
                        GameObject.Destroy(Target.transform.parent.gameObject);
                    }
                    if (LastSelectedObject)
                    {
                        Destroy(LastSelectedObject.GetComponent<Outline>());
                        LastSelectedObject = null;
                    }
                }

            }
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (!IsPointerOverGameObject(Input.mousePosition))
                {
                    if (Physics.Raycast(ray, out hit))
                    {
                        Debug.DrawLine(ray.origin, hit.point);
                        GameObject Target = hit.collider.gameObject;
                        if (LastSelectedObject)
                        {
                            Destroy(LastSelectedObject.GetComponent<Outline>());
                            LastSelectedObject = null;
                        }
                    }
                    else if (LastSelectedObject)
                    {
                        Destroy(LastSelectedObject.GetComponent<Outline>());
                        LastSelectedObject = null;
                    }
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                //清除上一个选中目标
                GameObject[] buildings;
                buildings = GameObject.FindGameObjectsWithTag("buildings");
                if (buildings.Length > 0)
                {
                    for (int i = 0; i < buildings.Length; i++)
                    {
                        try
                        {
                            Destroy(buildings[i].GetComponent<Outline>());
                        }
                        catch (Exception e)
                        {
                            Debug.Log(e);
                        }
                    }
                }

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit) && !IsPointerOverGameObject(Input.mousePosition))
                {
                    Debug.DrawLine(ray.origin, hit.point);
                    GameObject Target = hit.collider.gameObject;
                    
                    if (Target.transform.parent)
                    {
                        Target.AddComponent<Outline>();
                        Target.GetComponent<Outline>().OutlineWidth = 4;

                    }
                }

            }
        }

    }


    public bool IsPointerOverGameObject(Vector2 screenPosition)
    {

        //实例化点击事件        
        PointerEventData eventDataCurrentPosition = new PointerEventData(UnityEngine.EventSystems.EventSystem.current);
        //将点击位置的屏幕坐标赋值给点击事件        
        eventDataCurrentPosition.position = new Vector2(screenPosition.x, screenPosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        try
        {
            //向点击处发射射线        
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        }
        catch (Exception)
        {

        }
        return results.Count > 0;

    }
}