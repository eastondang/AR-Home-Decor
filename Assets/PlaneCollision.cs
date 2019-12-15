using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCollision : MonoBehaviour
{
    float timer = 0;//
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.1)
        {
            timer = 0;
            for (int j = 0; j < GameObject.Find("Plane Generator").transform.childCount; j++)//
            {
                if (GameObject.Find("Plane Generator").transform.GetChild(j))
                {
                    GameObject.Find("Plane Generator").transform.GetChild(j).gameObject.layer = LayerMask.NameToLayer("Surface");
                    Destroy(GameObject.Find("Plane Generator").transform.GetChild(j).GetComponent<MeshCollider>());
                    GameObject.Find("Plane Generator").transform.GetChild(j).gameObject.AddComponent<MeshCollider>();
                    GameObject.Find("Plane Generator").transform.GetChild(j).gameObject.GetComponent<MeshCollider>().convex = true;
                }
            }
        }
    }
}
