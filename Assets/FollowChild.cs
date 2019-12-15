using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowChild : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "S5")
        {
            Vector3 position;
            position = gameObject.transform.Find("default").transform.position;
            gameObject.transform.position = new Vector3(gameObject.transform.Find("default").transform.position.x + 0.14f,
                                                       gameObject.transform.Find("default").transform.position.y - 0.0197f,
                                                       gameObject.transform.Find("default").transform.position.z + 0.1396f);
            gameObject.transform.Find("default").transform.position = position;
        }
        Quaternion quaternion;
        quaternion = gameObject.transform.Find("default").transform.rotation;
        gameObject.transform.rotation = quaternion;
        gameObject.transform.Find("default").transform.rotation = quaternion;
    }
}
