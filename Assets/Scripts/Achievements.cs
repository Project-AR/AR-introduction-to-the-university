using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{
    public GameObject PanelTrue;
    public GameObject PanelFalse1;
    public GameObject PanelFalse2;
    public GameObject PanelFalse3;
    public GameObject PanelFalse4; 
    public void hidePanel()
    {
        PanelTrue.gameObject.SetActive(true);
        PanelFalse1.gameObject.SetActive(false);
        PanelFalse2.gameObject.SetActive(false);
        PanelFalse3.gameObject.SetActive(false);
        PanelFalse4.gameObject.SetActive(false);
    }

}
