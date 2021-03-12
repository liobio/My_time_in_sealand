using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Manager : MonoBehaviour
{
    static Inventory_Manager instance;

    public Inventory my_inventory;
    public GameObject slot_gird;
    // public Slot slot_prefab;
    public GameObject empty_slot;
    public Text ui_item_name;
    public List<GameObject> slots = new List<GameObject>();
    public static int Max_slot_number;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
        Max_slot_number = instance.my_inventory.Item_List.Count;
    }
    private void OnEnable()
    {
        Refresh_quick_bar();
        instance.ui_item_name.text = "";
       
    }

    public static void Updata_Item_name(string Item_name)
    {
        instance.ui_item_name.text = Item_name;

    } 
    /*public static void Creat_new_Item(Item item,int i)
    {
        Slot newItem = Instantiate(instance.slot_prefab, instance.slot_gird.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slot_gird.transform,false);
        newItem.slot_item = item;
        newItem.slot_image.sprite = item.item_image;
        newItem.slot_hold_number.text = item.itemheld.ToString();
        newItem.slot_number = i;

    }*/

    public static void Refresh_quick_bar()
    {
        for (int i = 0; i < instance.slot_gird.transform.childCount; i++)
        {
            if (instance.slot_gird.transform.childCount == 0)
            {
                break;
            }
            Destroy(instance.slot_gird.transform.GetChild(i).gameObject);
            instance.slots.Clear();
            Debug.Log("物品栏：" + i + "已清除");
        }
        for (int i = 0; i < instance.my_inventory.Item_List.Count; i++)
        {
          //  Creat_new_Item(instance.my_inventory.Item_List[i],i);
            instance.slots.Add(Instantiate(instance.empty_slot));
            instance.slots[i].transform.SetParent(instance.slot_gird.transform,false);
            instance.slots[i].GetComponent<Slot>().Setupslot(instance.my_inventory.Item_List[i]);
            instance.slots[i].GetComponent<Slot>().slot_ID = i;

            Debug.Log(instance.slot_gird.transform.GetChild(i).gameObject + "已创建");
        }
      
    }

    public static void Refresh_Item(int i)
    {
        instance.slots[i].GetComponent<Slot>().Setupslot(instance.my_inventory.Item_List[i]);
        Debug.Log(instance.slots[i].GetComponent<Slot>().slot_ID+"已刷新");
    }

    public static Vector3 Get_slot_position(int number)
    {
        Vector3 temp;
        try 
        {
            temp = instance.slot_gird.transform.GetChild(number).position;
        }
        catch
        {
            temp = Wheel_select_item.sel_image_pos_temp.pos;

        }
       
    
        return temp;
    }

}
