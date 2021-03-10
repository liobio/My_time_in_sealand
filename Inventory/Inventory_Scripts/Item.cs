using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New item",menuName ="Inventory/New item")]
public class Item : ScriptableObject
{

    public string Item_name;
    public Sprite item_image;
    public int itemheld;
    public bool Istile;


}
