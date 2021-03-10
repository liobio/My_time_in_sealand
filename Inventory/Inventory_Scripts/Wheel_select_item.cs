using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Wheel_select_item : MonoBehaviour
{

    public  Select_image_info sel_image_pos;
    public static Select_image_info sel_image_pos_temp;
    //public float first_x = 388.5f;
    //public float distance = 42;
    //public static float position_x;
    public static int sel_slot_number = 0;
    public Image select;
    public static Image select_image;

    public static Vector3 ischangtemp;



    private void Awake()
    {
        select_image = select;
        sel_image_pos_temp = sel_image_pos;
        sel_slot_number = sel_image_pos_temp.select_number;
        select_image.transform.position = sel_image_pos_temp.pos;//加载上次存储的位置
        Debug.Log("成功加载位置");
    }
   
    void Start()
    {

        
    }

   

    
    // Update is called once per frame
    void Update()
    {
        if (Select_ui())//通过鼠标滑轮选择物品
        {
           
            sel_image_pos_temp.pos= Inventory_Manager.Get_slot_position(sel_slot_number);
            select_image.transform.position = sel_image_pos_temp.pos;
            //选择框位置改变
            Debug.Log(Inventory_Manager.Get_slot_position(sel_slot_number));

            //储存的位置信息也同时更新


        }
        //没有滑轮响应时，通过点击slot的bottom也可以选择
        if (ischangtemp == Inventory_Manager.Get_slot_position(sel_slot_number))
        {
            return;
        }
            
        else
        {
            ischangtemp = Inventory_Manager.Get_slot_position(sel_slot_number);
            sel_image_pos_temp.pos = Inventory_Manager.Get_slot_position(sel_slot_number);
            select_image.transform.position = sel_image_pos_temp.pos;
            Debug.Log("wheel change");
        }
        
        
        //储存的位置信息也同时更新

    }
    public bool Select_ui()
    {


        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            sel_slot_number--;
            if (sel_slot_number == -1)
            {
                sel_slot_number = 9;
            }
            sel_image_pos_temp.select_number= sel_slot_number;
          

          
            return true;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            sel_slot_number++;
            if (sel_slot_number == 10)
            {
                sel_slot_number = 0;
            }
            sel_image_pos_temp.select_number = sel_slot_number;
  
            return true;
        }
     
        return false;

    }
}
