using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_on_world : MonoBehaviour
{
    public Item this_Item;//掉落在世界上的物品种类
    public Inventory player_quickbar;//拾取到哪个背包
    public int stack_number;//堆叠数目
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
            Inventory_Manager.Refresh_quick_bar();
            Debug.Log("成功添加新物品！");
        }
        else
        {
            this_Item.itemheld += stack_number;
            //为解决拾取物品时 选择框会刷新到其他地方 采用一格一格的刷新 而不摧毁再重建
            for (int i = 0; i < 10; i++)
            {
                Inventory_Manager.Refresh_Item(i);
               
            }
        }
       

    }
}
