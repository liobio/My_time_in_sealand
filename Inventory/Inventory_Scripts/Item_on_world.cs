using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_on_world : MonoBehaviour
{
    public Item this_Item;
    public Inventory player_quickbar;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("触碰！");
            Add_newItem();
            Destroy(gameObject);
        }

    }
    public void Add_newItem()
    {
        if (!player_quickbar.Item_List.Contains(this_Item))
        {
            // player_quickbar.Item_List.Add(this_Item);

            //Inventory_Manager.Creat_new_Item(this_Item);

            for (int i = 0; i < 10; i++)
            {
                if (player_quickbar.Item_List[i] == null)
                {
                    player_quickbar.Item_List[i] = this_Item;
                    break;
                }
            }
            Debug.Log("成功添加新物品！");
        }
        else
        {
            this_Item.itemheld++;
            Debug.Log("数量+1！"); 
        }
        for(int i = 0; i < 10; i++)
        {
            Inventory_Manager.Refresh_Item(i);
        }
       
    }
}
