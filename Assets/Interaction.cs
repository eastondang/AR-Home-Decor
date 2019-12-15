
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;


public class Interaction : MonoBehaviour
{

    private GameObject[] buildings;
    private GameObject surface;
    private float timer = 0;
    float timerReward = 0;
    bool haveReward = false;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        this.buildings = GameObject.FindGameObjectsWithTag("buildings");
        if (this.buildings.Length > 0)
        {
            for (int i = 0; i < this.buildings.Length; i++)
            {
                if(this.buildings[i].transform.position.y < -40)
                {
                    GameObject.Destroy(this.buildings[i].transform.parent.gameObject);
                }
            }
        }


    }
}
