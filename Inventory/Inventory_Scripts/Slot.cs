using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

    public Item slot_item;
    public Image slot_image;
    public Text slot_hold_number;
    public int slot_ID;//物品槽的序号
    public GameObject iteminslot;
    public string slotinfo_name;
    public bool isuse=false;

  

    private Dictionary<string, string> Slotname_to_TilesName = new Dictionary<string, string>();
    private void Start()
    {
        Slotname_to_TilesName.Add("泥土","glass_tile");
        
    }

    public  void  ItemOnClicked()
    {
        
        

        Inventory_Manager.Updata_Item_name(slotinfo_name);
        Wheel_select_item.sel_slot_number = slot_ID;

        StartCoroutine(Delay_Disappear());
        if (slot_item == null)
        {
            return;
        }

        if (slot_item.Istile)
        {
            Tile_Item_use.baseTile = Map_ctrl.Dec_name_to_Tiles[Slotname_to_TilesName[slot_item.Item_name]];
            Tile_Item_use.use_tile_item = AssetDatabase.LoadAssetAtPath("Assets/Inventory/Items/" + Slotname_to_TilesName[slot_item.Item_name] + ".asset", typeof(UnityEngine.ScriptableObject)) as Item;
        }
        else
        {
            Tile_Item_use.baseTile = null;
        }




    }
    public void Setupslot(Item item)
    {
        if (item == null)
        {
            slot_image.color = new Color(1, 1, 1, 0);
            slotinfo_name =" ";
            iteminslot.SetActive(false);
            return;
        }
        slot_item = item;
        slot_image.sprite = item.item_image;
        slot_image.color = new Color(1, 1, 1, 1);
        slot_hold_number.text = item.itemheld.ToString();
        slotinfo_name = item.Item_name;
    }

    private void Update()
    {
        
        if (Wheel_ctr()&&!isuse)
        {

            ItemOnClicked();
            
            isuse = true;
        }
        if(!Wheel_ctr())
        {
            isuse = false;
        }
        
        
        
    }

    public bool Wheel_ctr()
    {
        if (slot_ID == Wheel_select_item.sel_slot_number)
        {
            
            return true;
        }
        return false;
    }


    private IEnumerator Delay_Disappear()
    {
        yield return new WaitForSeconds(3);
        ShowB();
    }
    private void ShowB()
    {
        Inventory_Manager.Updata_Item_name("");
    }
   


}
