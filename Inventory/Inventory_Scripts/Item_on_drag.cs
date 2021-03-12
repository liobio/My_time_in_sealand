using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Item_on_drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform original_parent;
    public Inventory my_bar;
    private int current_item_iD;

    public void OnBeginDrag(PointerEventData eventData)
    {
        original_parent = transform.parent;
        current_item_iD = original_parent.GetComponent<Slot>().slot_ID;
        transform.SetParent(transform.parent.parent);
        transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
       // Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject.name == "item_Image")//判断下面的物体名字；如果存在物品则对调
        {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
            transform.position=eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;

            //itemlist物品存储位置改变
            var temp = my_bar.Item_List[current_item_iD];
            my_bar.Item_List[current_item_iD] = my_bar.Item_List[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slot_ID];
            my_bar.Item_List[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slot_ID] = temp;

            eventData.pointerCurrentRaycast.gameObject.transform.parent.position = original_parent.position;
            eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(original_parent);
        
            GetComponent<CanvasGroup>().blocksRaycasts = true;//射线阻挡开启 不然无法再次选中移动的物品

            Inventory_Manager.Refresh_quick_bar();

            return;
        }


        //直接挂载到slot的物品槽内
        if (eventData.pointerCurrentRaycast.gameObject.name == "slot(Clone)")
        {


            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;

            //itemlist物品存储位置改变
            my_bar.Item_List[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slot_ID] = my_bar.Item_List[current_item_iD];

            if (eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().slot_ID != current_item_iD)//不放在自己位置时，才清理旧位置的物品
            {
                my_bar.Item_List[current_item_iD] = null;
            }
            GetComponent<CanvasGroup>().blocksRaycasts = true;

            Inventory_Manager.Refresh_quick_bar();

            return;
        }

        //else
        //{
        //    transform.SetParent(original_parent);
        //    transform.position = original_parent.position;
        //    GetComponent<CanvasGroup>().blocksRaycasts = true;

        //}



    }


}
