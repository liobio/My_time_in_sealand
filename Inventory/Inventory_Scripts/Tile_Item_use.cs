using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tile_Item_use : MonoBehaviour
{
    public static Item use_tile_item;//ͨ��slot����ķ��������Ӧ����Ʒ�����ļ� ֻ������Ƭ��Ʒʱ�Ŵ���
    public Tilemap tilemap;//���õ�Tilemap
    public static TileBase baseTile;//ʹ�õ������Ƭ��Ʒ

    void Update()
    {

        //if (use_tile_item == null)
        //{
        //    Debug.Log("��Ƭ��ƷΪ��");
        //    return;
        //}

        //if (baseTile == null)
        //{
        //    Debug.Log("û��ѡ����Ƭ"+use_tile_item.Item_name);
        //    return;
        //}

        //if (use_tile_item.itemheld < 1)
        //{
        //    Debug.Log("��������"+use_tile_item.Item_name);
        //    return;
        //}

        //�һ��հ׵ط�������Ƭ
        if (use_tile_item.Item_name == "����" && Input.GetMouseButtonDown(1))
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 wordPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3Int cellPosition = tilemap.WorldToCell(wordPosition);
            TileBase tb = tilemap.GetTile(cellPosition);

            TileBase up_tile = tilemap.GetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z));
            TileBase down_tile = tilemap.GetTile(new Vector3Int(cellPosition.x, cellPosition.y - 1, cellPosition.z));
            TileBase left_tile = tilemap.GetTile(new Vector3Int(cellPosition.x-1, cellPosition.y , cellPosition.z));
            TileBase right_tile = tilemap.GetTile(new Vector3Int(cellPosition.x+1, cellPosition.y , cellPosition.z));
            TileBase right_up_tile = tilemap.GetTile(new Vector3Int(cellPosition.x + 1, cellPosition.y+1, cellPosition.z));
            TileBase right_down_tile = tilemap.GetTile(new Vector3Int(cellPosition.x + 1, cellPosition.y-1, cellPosition.z));
            TileBase left_up_tile = tilemap.GetTile(new Vector3Int(cellPosition.x - 1, cellPosition.y+1, cellPosition.z));
            TileBase left_down_tile = tilemap.GetTile(new Vector3Int(cellPosition.x - 1, cellPosition.y-1, cellPosition.z));

           
           
           
            if (tb == Map_ctrl.Dec_name_to_Tiles["right_land_tile"])
            {
                if (up_tile == Map_ctrl.Dec_name_to_Tiles["right_land_tile"] && down_tile == Map_ctrl.Dec_name_to_Tiles["right_land_tile"])
                {
                    tilemap.SetTile(cellPosition, baseTile);
                    tilemap.SetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_down_land_tile"]);
                    tilemap.SetTile(new Vector3Int(cellPosition.x, cellPosition.y - 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_up_land_tile"]);
                    tilemap.SetTile(new Vector3Int(cellPosition.x - 1, cellPosition.y, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_land_tile"]);
                    tilemap.SetTile(new Vector3Int(cellPosition.x - 1, cellPosition.y + 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_down_corner_tile"]);
                    tilemap.SetTile(new Vector3Int(cellPosition.x - 1, cellPosition.y - 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_up_corner_tile"]);
                    use_tile_item.itemheld--;
                    Debug.Log(use_tile_item.itemheld);
                    
                }
            }

            if (tb == Map_ctrl.Dec_name_to_Tiles["right_up_land_tile"])
            {
                if (up_tile == Map_ctrl.Dec_name_to_Tiles["glass_tile"] && down_tile == Map_ctrl.Dec_name_to_Tiles["right_land_tile"])
                {
                    tilemap.SetTile(cellPosition, baseTile);
                    //tilemap.SetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_down_land_tile"]);
                    tilemap.SetTile(new Vector3Int(cellPosition.x, cellPosition.y - 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_up_land_tile"]);
                    tilemap.SetTile(new Vector3Int(cellPosition.x - 1, cellPosition.y, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_land_tile"]);
                    tilemap.SetTile(new Vector3Int(cellPosition.x - 1, cellPosition.y + 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_land_tile"]);
                    tilemap.SetTile(new Vector3Int(cellPosition.x - 1, cellPosition.y - 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_up_corner_tile"]);
                    use_tile_item.itemheld--;
                    Debug.Log(use_tile_item.itemheld);
                    
                }
            }
            if (tb == Map_ctrl.Dec_name_to_Tiles["right_up_land_tile"])
            {
                if (up_tile == Map_ctrl.Dec_name_to_Tiles["glass_tile"] && down_tile == Map_ctrl.Dec_name_to_Tiles["right_down_land_tile"])
                {
                    tilemap.SetTile(cellPosition, baseTile);
                    //center
                    //tilemap.SetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_down_land_tile"]);
                    //up
                    tilemap.SetTile(new Vector3Int(cellPosition.x, cellPosition.y - 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["left_hole_land_tile"]);
                    //down
                    tilemap.SetTile(new Vector3Int(cellPosition.x - 1, cellPosition.y, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_land_tile"]);
                    //left
                    tilemap.SetTile(new Vector3Int(cellPosition.x - 1, cellPosition.y + 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_land_tile"]);
                    //left_up
                    tilemap.SetTile(new Vector3Int(cellPosition.x - 1, cellPosition.y - 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["double_right_corner_tile"]);
                    //left_down
                    //tilemap.SetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_down_land_tile"]);
                    //right
                    //tilemap.SetTile(new Vector3Int(cellPosition.x+1, cellPosition.y + 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_down_land_tile"]);
                    //right_up
                    //tilemap.SetTile(new Vector3Int(cellPosition.x+1, cellPosition.y - 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_down_land_tile"]);
                    //right_down
                    use_tile_item.itemheld--;
                    Debug.Log(use_tile_item.itemheld);
                   
                }
            }
            if (tb == Map_ctrl.Dec_name_to_Tiles["left_hole_land_tile"])
            {
                if (up_tile == Map_ctrl.Dec_name_to_Tiles["glass_tile"] && down_tile == Map_ctrl.Dec_name_to_Tiles["glass_tile"] && left_tile== Map_ctrl.Dec_name_to_Tiles["double_right_corner_tile"]&& right_tile == Map_ctrl.Dec_name_to_Tiles["glass_tile"])
                {
                    tilemap.SetTile(cellPosition, baseTile);
                    //center
                    //tilemap.SetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_down_land_tile"]);
                    //up
                    //tilemap.SetTile(new Vector3Int(cellPosition.x, cellPosition.y - 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["left_hole_land_tile"]);
                    //down
                    tilemap.SetTile(new Vector3Int(cellPosition.x - 1, cellPosition.y, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_land_tile"]);
                    //left
                    //tilemap.SetTile(new Vector3Int(cellPosition.x - 1, cellPosition.y + 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_land_tile"]);
                    //left_up
                    //tilemap.SetTile(new Vector3Int(cellPosition.x - 1, cellPosition.y - 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["double_right_corner_tile"]);
                    //left_down
                    //tilemap.SetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_down_land_tile"]);
                    //right
                    //tilemap.SetTile(new Vector3Int(cellPosition.x+1, cellPosition.y + 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_down_land_tile"]);
                    //right_up
                    //tilemap.SetTile(new Vector3Int(cellPosition.x+1, cellPosition.y - 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_down_land_tile"]);
                    //right_down
                    use_tile_item.itemheld--;
                    Debug.Log(use_tile_item.itemheld);
                 
                }
            }

            if (tb == Map_ctrl.Dec_name_to_Tiles["right_down_land_tile"])
            {
                if (up_tile == Map_ctrl.Dec_name_to_Tiles["glass_tile"] && down_tile == Map_ctrl.Dec_name_to_Tiles["glass_tile"] && left_tile == Map_ctrl.Dec_name_to_Tiles["right_down_corner_tile"] && right_tile == Map_ctrl.Dec_name_to_Tiles["glass_tile"])
                {
                    tilemap.SetTile(cellPosition, baseTile);
                    //center
                    //tilemap.SetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_down_land_tile"]);
                    //up
                    //tilemap.SetTile(new Vector3Int(cellPosition.x, cellPosition.y - 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["left_hole_land_tile"]);
                    //down
                    tilemap.SetTile(new Vector3Int(cellPosition.x - 1, cellPosition.y, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_land_tile"]);
                    //left
                    //tilemap.SetTile(new Vector3Int(cellPosition.x - 1, cellPosition.y + 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_land_tile"]);
                    //left_up
                    //tilemap.SetTile(new Vector3Int(cellPosition.x - 1, cellPosition.y - 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["double_right_corner_tile"]);
                    //left_down
                    //tilemap.SetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_down_land_tile"]);
                    //right
                    //tilemap.SetTile(new Vector3Int(cellPosition.x+1, cellPosition.y + 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_down_land_tile"]);
                    //right_up
                    //tilemap.SetTile(new Vector3Int(cellPosition.x+1, cellPosition.y - 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_down_land_tile"]);
                    //right_down
                    use_tile_item.itemheld--;
                    Debug.Log(use_tile_item.itemheld);
                  
                }
            }
            if (tb == Map_ctrl.Dec_name_to_Tiles["right_down_land_tile"])
            {
                if (up_tile == Map_ctrl.Dec_name_to_Tiles["right_up_corner_tile"] && down_tile == Map_ctrl.Dec_name_to_Tiles["right_down_land_tile"] 
                    && left_tile == Map_ctrl.Dec_name_to_Tiles["sea_tile"] && right_tile == Map_ctrl.Dec_name_to_Tiles["glass_tile"])

                {
                    tilemap.SetTile(cellPosition, baseTile);
                    //center
                    //tilemap.SetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_down_land_tile"]);
                    //up
                    //tilemap.SetTile(new Vector3Int(cellPosition.x, cellPosition.y - 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["left_hole_land_tile"]);
                    //down
                    tilemap.SetTile(new Vector3Int(cellPosition.x - 1, cellPosition.y, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_land_tile"]);
                    //left
                    //tilemap.SetTile(new Vector3Int(cellPosition.x - 1, cellPosition.y + 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_land_tile"]);
                    //left_up
                    //tilemap.SetTile(new Vector3Int(cellPosition.x - 1, cellPosition.y - 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["double_right_corner_tile"]);
                    //left_down
                    //tilemap.SetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_down_land_tile"]);
                    //right
                    //tilemap.SetTile(new Vector3Int(cellPosition.x+1, cellPosition.y + 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_down_land_tile"]);
                    //right_up
                    //tilemap.SetTile(new Vector3Int(cellPosition.x+1, cellPosition.y - 1, cellPosition.z), Map_ctrl.Dec_name_to_Tiles["right_down_land_tile"]);
                    //right_down
                    use_tile_item.itemheld--;
                    Debug.Log(use_tile_item.itemheld);
                 
                }
            }
            Inventory_Manager.Refresh_Item(Wheel_select_item.sel_slot_number);


        }
    }
}
