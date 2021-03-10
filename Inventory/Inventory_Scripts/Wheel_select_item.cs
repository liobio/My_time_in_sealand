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
        select_image.transform.position = sel_image_pos_temp.pos;//�����ϴδ洢��λ��
        Debug.Log("�ɹ�����λ��");
    }
   
    void Start()
    {

        
    }

   

    
    // Update is called once per frame
    void Update()
    {
        if (Select_ui())//ͨ����껬��ѡ����Ʒ
        {
           
            sel_image_pos_temp.pos= Inventory_Manager.Get_slot_position(sel_slot_number);
            select_image.transform.position = sel_image_pos_temp.pos;
            //ѡ���λ�øı�
            Debug.Log(Inventory_Manager.Get_slot_position(sel_slot_number));

            //�����λ����ϢҲͬʱ����


        }
        //û�л�����Ӧʱ��ͨ�����slot��bottomҲ����ѡ��
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
        
        
        //�����λ����ϢҲͬʱ����

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
