using System;
using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using protobuf.plant;
using protobuf.table;
using UnityEngine;

public class FlowerSellModel : Singleton<FlowerSellModel>
{
    private Dictionary<uint, TableVo> tableDic;
    public bool isSelectFlowerShelfing = false;//选花上架中
    public float orthoSize;//之前的orthoSize
    public Vector3 cameraPos;//之前的cameraPos
    public int selectDeskId = 0;

    public int unlockTable { get
        {
            if(tableDic != null)
            {
                return tableDic.Count;
            }
            return 0;
        } }
    public void InitTables(List<I_TABLE_VO> tableList)
    {
        tableDic = new Dictionary<uint, TableVo>();
        foreach (var table in tableList)
        {
            TableVo tableVo = new TableVo();
            tableVo.ParseData(table);
            tableDic.Add(tableVo.deskId, tableVo);
        }
    }

    public TableVo GetTableVo(uint tableId)
    {
        if (tableDic.TryGetValue(tableId, out TableVo flowerStandData))
        {
            return flowerStandData;
        }
        return null;
    }

    public TableVo UpdateTable(I_TABLE_VO i_TABLE_VO)
    {
        var tableVo = GetTableVo(i_TABLE_VO.gridId);
        if (tableVo != null)
        {
            tableVo.ParseData(i_TABLE_VO);
        }
        else
        {
            tableVo = new TableVo();
            tableVo.ParseData(i_TABLE_VO);
            tableDic.Add(i_TABLE_VO.gridId, tableVo);
        }
        return tableVo;
    }

    private Ft_tableConfigData table_ConfigConfigData;
    public Ft_tableConfig GetTabelConfig(int id)
    {
        table_ConfigConfigData ??= ConfigManager.Instance.GetConfig<Ft_tableConfigData>("ft_tablesConfig");
        return table_ConfigConfigData.Get(id);
    }

    //private Building_flowershelfConfigData building_FlowershelfConfigData;
    //public Building_flowershelfConfig GetFlowerSellConfig(int id)
    //{
    //    building_FlowershelfConfigData ??= ConfigManager.Instance.GetConfig<Building_flowershelfConfigData>("ft_building_flowershelfConfig");
    //    return building_FlowershelfConfigData.Get(id);
    //}
}

