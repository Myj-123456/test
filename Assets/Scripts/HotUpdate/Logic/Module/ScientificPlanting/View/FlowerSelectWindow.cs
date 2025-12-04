
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlowerSelectWindow : BaseWindow
{
   private fun_ResearchPlanting.FlowerSelectView view;
    private List<SeedCropVO> listData;
    private float curPage;
    private float maxPage;

   public FlowerSelectWindow()
    {
        packageName = "fun_ResearchPlanting";
        // 设置委托
        BindAllDelegate = fun_ResearchPlanting.fun_ResearchPlantingBinder.BindAll;
        CreateInstanceDelegate = fun_ResearchPlanting.FlowerSelectView.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_ResearchPlanting.FlowerSelectView;
        view.list.itemRenderer = RenderList;

        view.btn_turn_left.onClick.Add(() =>
        {
            if (curPage == 0)
            {
                curPage = maxPage;
            }
            else
            {
                curPage--;
            }
            UpdateList();
        });
        view.btn_turn_right.onClick.Add(() =>
        {
            if(curPage == maxPage)
            {
                curPage = 0;
            }
            else
            {
                curPage++;
            }
            UpdateList();
        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        listData = FlowerStarModel.Instance.GetFlowersList();
        curPage = 1;
        maxPage = Mathf.Ceil((float)listData.Count / 16f);
        UpdateList();
    }

    private void UpdateList()
    {
        int count = 16;
        if(curPage == maxPage)
        {
            count = listData.Count - (int)(curPage - 1) * 16;
        }
        view.list.numItems = count;
        view.lb_pageCount.text = curPage + "/" + maxPage;
    }

    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_ResearchPlanting.FkowerSelectItem;
        var crop = listData[((int)curPage - 1) * 16 + index];
        cell.img_flower.url = "";
        cell.img_flower.url = ImageDataModel.Instance.GetIconUrl(crop.item);
        cell.lb_level.text = crop.level.ToString();
        cell.data = crop;
        var flower = FlowerStarModel.Instance.GetFlowerStarInfo(crop.flowerId);
        cell.ls_star.itemRenderer = (int index, GObject starItem) =>
        {
            
            var starCell = starItem as fun_ResearchPlanting.ScientStar;
            if(flower != null)
            {
                var lv = GlobalModel.Instance.module_profileConfig.flowerStarPremise[index];
                if(flower.buff[(uint)index] != 0)
                {
                    starCell.status.selectedIndex = 0;
                }
                else if(crop.level >= lv)
                {
                    starCell.status.selectedIndex = 1;
                }
                else
                {
                    starCell.status.selectedIndex = 2;
                }
            }
            else
            {
                starCell.status.selectedIndex = 2;
            }
        };
        cell.ls_star.numItems = GlobalModel.Instance.module_profileConfig.flowerStarPremise.Count;
        cell.onClick.Add(FlowerClickHander);
    }

    private void FlowerClickHander(EventContext context)
    {
        var crop = (context.sender as GComponent).data as SeedCropVO;
        EventManager.Instance.DispatchEvent<SeedCropVO>(FlowerStarEvent.FlowerStarSelect, crop);
        Close();
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

