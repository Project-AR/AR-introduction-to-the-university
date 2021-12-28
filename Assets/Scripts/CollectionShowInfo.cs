using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionShowInfo : MonoBehaviour
{
    public CollectionItemData Item;

    public Text Name;
    public Text Info;
    public Image Image;

    public GameObject Show;

    public void ShowInfo()
    {
        Show.SetActive(true);

        Name.text = Item.Data.Name;
        Info.text = Item.Data.TextInfo;
        Image.sprite = Item.Data.Image;
    }
}
