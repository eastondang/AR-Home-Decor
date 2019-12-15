
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;


public class ButtonSelected : MonoBehaviour
{
    public GameObject BuildObject = null;
    public int seleted = 0;



    void ResetButtons()
    {
        GameObject.Find("Canvas/Info/Scroll View/Viewport/Content/S1").GetComponent<Image>().color = new Color(0.8962264f, 0.8962264f, 0.8962264f, 0.7F);
        GameObject.Find("Canvas/Info/Scroll View/Viewport/Content/S2").GetComponent<Image>().color = new Color(0.8962264f, 0.8962264f, 0.8962264f, 0.7F);
        GameObject.Find("Canvas/Info/Scroll View/Viewport/Content/S3").GetComponent<Image>().color = new Color(0.8962264f, 0.8962264f, 0.8962264f, 0.7F);
        GameObject.Find("Canvas/Info/Scroll View/Viewport/Content/S4").GetComponent<Image>().color = new Color(0.8962264f, 0.8962264f, 0.8962264f, 0.7F);
        GameObject.Find("Canvas/Info/Scroll View/Viewport/Content/S5").GetComponent<Image>().color = new Color(0.8962264f, 0.8962264f, 0.8962264f, 0.7F);
        GameObject.Find("Canvas/Info/Scroll View/Viewport/Content/S1").transform.localScale = new Vector2(1, 1);
        GameObject.Find("Canvas/Info/Scroll View/Viewport/Content/S2").transform.localScale = new Vector2(1, 1);
        GameObject.Find("Canvas/Info/Scroll View/Viewport/Content/S3").transform.localScale = new Vector2(1, 1);
        GameObject.Find("Canvas/Info/Scroll View/Viewport/Content/S4").transform.localScale = new Vector2(1, 1);
        GameObject.Find("Canvas/Info/Scroll View/Viewport/Content/S5").transform.localScale = new Vector2(1, 1);
        GameObject.Find("Canvas/Buttons/B101").transform.localScale = new Vector2(1.8f, 1.8f);
        GameObject.Find("Canvas/Buttons/B102").transform.localScale = new Vector2(1.8f, 1.8f);
        GameObject.Find("Canvas/Buttons/B103").transform.localScale = new Vector2(1.8f, 1.8f);

    }
    // Start is called before the first frame update
    void Start()
    {
        seleted = 1;
        string path = "RFAIPP_Chair";
        BuildObject = (GameObject)(Resources.Load(path));
        try
        {
            ResetButtons();
            GameObject.Find("Canvas/Info/Scroll View/Viewport/Content/S1").GetComponent<Image>().color = new Color(1, 1, 1, 1F);
            GameObject.Find("Canvas/Info/Scroll View/Viewport/Content/S1").transform.localScale = new Vector2(1.05f, 1.05f);
        }
        catch (Exception)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        try
        {

        }
        catch (System.Exception)
        {

        }
    }
    public void S1()
    {
        if (seleted != 1)
        {
            seleted = 1;
            string path = "RFAIPP_Chair";
            BuildObject = (GameObject)(Resources.Load(path));
            ResetButtons();
            GameObject.Find("Canvas/Info/Scroll View/Viewport/Content/S1").GetComponent<Image>().color = new Color(1, 1, 1, 1F);
            GameObject.Find("Canvas/Info/Scroll View/Viewport/Content/S1").transform.localScale = new Vector2(1.05f, 1.05f);
        }
    }
    public void S2()
    {
        if (seleted != 2)
        {
            seleted = 2;
            string path = "RFAIPP_Dining_Table";
            BuildObject = (GameObject)(Resources.Load(path));
            ResetButtons();
            GameObject.Find("Canvas/Info/Scroll View/Viewport/Content/S2").GetComponent<Image>().color = new Color(1, 1, 1, 1F);
            GameObject.Find("Canvas/Info/Scroll View/Viewport/Content/S2").transform.localScale = new Vector2(1.05f, 1.05f);
        }
    }
    public void S3()
    {
        if (seleted != 3)
        {
            seleted = 3;
            string path = "RFAIPP_Chandelier";
            BuildObject = (GameObject)(Resources.Load(path));
            ResetButtons();
            GameObject.Find("Canvas/Info/Scroll View/Viewport/Content/S3").GetComponent<Image>().color = new Color(1, 1, 1, 1F);
            GameObject.Find("Canvas/Info/Scroll View/Viewport/Content/S3").transform.localScale = new Vector2(1.05f, 1.05f);
        }
    }
    public void S4()
    {
        if (seleted != 4)
        {
            seleted = 4;
            string path = "RFAIPP_Sofa";
            BuildObject = (GameObject)(Resources.Load(path));
            ResetButtons();
            GameObject.Find("Canvas/Info/Scroll View/Viewport/Content/S4").GetComponent<Image>().color = new Color(1, 1, 1, 1F);
            GameObject.Find("Canvas/Info/Scroll View/Viewport/Content/S4").transform.localScale = new Vector2(1.05f, 1.05f);
        }
    }
    public void S5()
    {
        if (seleted != 5)
        {
            seleted = 5;
            string path = "RFAIPP_Pouf";
            BuildObject = (GameObject)(Resources.Load(path));
            ResetButtons();
            GameObject.Find("Canvas/Info/Scroll View/Viewport/Content/S5").GetComponent<Image>().color = new Color(1, 1, 1, 1F);
            GameObject.Find("Canvas/Info/Scroll View/Viewport/Content/S5").transform.localScale = new Vector2(1.05f, 1.05f);
        }
    }
    public void B101()//移动
    {
        if (seleted != 101)
        {
            seleted = 101;
            BuildObject = null;
            ResetButtons();
            GameObject.Find("Canvas/Buttons/B101").transform.localScale = new Vector2(2.1f, 2.1f);
        }
    }
    public void B102()//旋转
    {
        if (seleted != 102)
        {
            seleted = 102;
            BuildObject = null;
            ResetButtons();
            GameObject.Find("Canvas/Buttons/B102").transform.localScale = new Vector2(2.1f, 2.1f);
        }
    }
    public void B103()//删除
    {
        if (seleted != 103)
        {
            seleted = 103;
            BuildObject = null;
            ResetButtons();
            GameObject.Find("Canvas/Buttons/B103").transform.localScale = new Vector2(2.1f, 2.1f);
        }
    }

}