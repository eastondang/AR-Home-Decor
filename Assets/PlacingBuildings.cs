using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlacingBuildings : MonoBehaviour
{
    GameObject Tip;
    public string showtext;
    public float timerShowTip = 0;
    // Start is called before the first frame update
    void Start()
    {
        Tip = GameObject.Find("Canvas/Tip");
        Tip.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerShowTip > 0)
        {
            Tip.SetActive(true);
            timerShowTip -= Time.deltaTime;
            Tip.GetComponent<Image>().color = new Color(1, 1, 1, timerShowTip / 1.5f);
            GameObject.Find("Canvas/Tip/Text").GetComponent<Text>().text = showtext;
            GameObject.Find("Canvas/Tip/Text").GetComponent<Text>().color = new Color(0.4941177f, 0.572549f, 0.8509805f, timerShowTip / 1.5f);
        }
        else
        {
            Tip.SetActive(false);
        }


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //if (Physics.Raycast(ray, out hit, 30.0f, LayerMask.GetMask("Surface")) && !IsPointerOverGameObject(Input.mousePosition))
            if (Physics.Raycast(ray, out hit) && !IsPointerOverGameObject(Input.mousePosition))
            {
                GameObject Target = hit.collider.gameObject;
                if (Target.layer == LayerMask.NameToLayer("Surface"))
                {
                        GameObject prefab = GameObject.Find("InteractionScript").GetComponent<ButtonSelected>().BuildObject;

                        //var andyObject = Instantiate(prefab, hit.Pose.position, hit.Pose.rotation);
                        var andyObject = Instantiate(prefab, hit.point, Quaternion.Euler(0, 0, 0));
                        //andyObject.transform.transform.Find("default").transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                }
            }
        }


    }


    public bool IsPointerOverGameObject(Vector2 screenPosition)
    {   //实例化点击事件        
        PointerEventData eventDataCurrentPosition = new PointerEventData(UnityEngine.EventSystems.EventSystem.current);
        //将点击位置的屏幕坐标赋值给点击事件        
        eventDataCurrentPosition.position = new Vector2(screenPosition.x, screenPosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        //向点击处发射射线        
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
    
}
