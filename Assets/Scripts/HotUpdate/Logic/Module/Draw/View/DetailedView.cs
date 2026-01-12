using System.Collections.Generic;
using Elida.Config;
using ADK;
using FairyGUI;

public class DetailedView : BaseWindow
{
    private fun_Draw.detailed_view view;
    private int activityId;
    public DetailedView()
    {
        packageName = "fun_Draw";
        BindAllDelegate = fun_Draw.fun_DrawBinder.BindAll;
        CreateInstanceDelegate = fun_Draw.detailed_view.CreateInstance;
    }
    public override void OnInit()
    {
        base.OnInit();
        view = (fun_Draw.detailed_view)ui;
        SetBg(view.bg, "Common/common_big_tip_bg.png");
        view.Text_Title.text = Lang.GetValue("detailed_01"); //概率详细
        view.btn_close.onClick.Add(() =>
        {
            Close();
        });
    }

    public override void OnShown()
    {
        base.OnShown();
        if (data != null)
        {
            activityId = (int)data;
            ShowProbabilityDetails();
        }
    }

    private void ShowProbabilityDetails()
    {
        view.list.RemoveChildrenToPool();
        var poolItems = DrawModel.Instance.drawPoolList.FindAll(item => item.EventId == activityId);
        
        if (poolItems.Count == 0) return;
        int totalWeight = 0;
        foreach (var item in poolItems)
        {
            totalWeight += item.Prob;
        }
        Dictionary<float, List<Ft_draw_poolConfig>> probabilityGroups = new Dictionary<float, List<Ft_draw_poolConfig>>();
        foreach (var item in poolItems)
        {
            float probability = (float)item.Prob / totalWeight * 100;
            if (!probabilityGroups.ContainsKey(probability))
            {
                probabilityGroups[probability] = new List<Ft_draw_poolConfig>();
            }
            probabilityGroups[probability].Add(item);
        }
        List<float> sortedProbabilities = new List<float>(probabilityGroups.Keys);
        sortedProbabilities.Sort();
        foreach (var prob in sortedProbabilities)
        {
            var groupItems = probabilityGroups[prob];
            var listItem = view.list.AddItemFromPool() as fun_Draw.detailed_list_Item;
            listItem.title.text = Lang.GetValue("detailed_02")+$"{prob:F1}%";
            listItem.list.RemoveChildrenToPool();
            foreach (var poolItem in groupItems)
            {
                foreach (var itemObj in poolItem.PoolItems)
                {
                    var detailedItem = listItem.list.AddItemFromPool() as fun_Draw.detailed_Item;
                    var itemConfig = ItemModel.Instance.GetItemByEntityID(itemObj.EntityID);
                    if (itemConfig != null)
                    {
                        detailedItem.pic.url = ImageDataModel.Instance.GetIconUrl(itemConfig);
                        detailedItem.bg.url = ImageDataModel.Instance.GetItemQuality(itemConfig.Quality);
                        detailedItem.numLab.text = itemObj.Value.ToString();
                        if (poolItem.IsBig == 1)
                        {
                            detailedItem.status.selectedIndex = 1;
                        }
                        else
                        {
                            detailedItem.status.selectedIndex = 0;
                        }
                    }
                }
            }
        }
    }
}
