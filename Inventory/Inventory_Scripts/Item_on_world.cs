using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_on_world : MonoBehaviour
{
    public Item this_Item;//�����������ϵ���Ʒ����
    public Inventory player_quickbar;//ʰȡ���ĸ�����
    public int stack_number;//�ѵ���Ŀ
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("������");
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
            Debug.Log("�ɹ��������Ʒ��");
        }
        else
        {
            this_Item.itemheld += stack_number;
            //Ϊ���ʰȡ��Ʒʱ ѡ����ˢ�µ������ط� ����һ��һ���ˢ�� �����ݻ����ؽ�
            for (int i = 0; i < 10; i++)
            {
                Inventory_Manager.Refresh_Item(i);
               
            }
        }
       

    }
}
