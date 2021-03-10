using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventorys", menuName = "Inventory/New Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> Item_List = new List<Item>();



}
