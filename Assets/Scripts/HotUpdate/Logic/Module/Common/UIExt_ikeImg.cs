
using FairyGUI;
using FairyGUI.Utils;

public partial class UIExt_ikeImg
{
    public static void LoadIkeByItemId(common_New.ikeImg cell,int itemId, bool small) {

        if (itemId != 0)
        {
            var formula = IkeModel.Instance.GetFormulaByItemId(itemId);
            if (formula == null) return;
            LoadIke(cell,formula.CombinationId, small);
        }

    }

    public static void LoadIke(common_New.ikeImg cell, int formulaId, bool small)
    {
        var formula = IkeModel.Instance.GetFormula(formulaId);
        int id_1 = int.Parse(formula.FlowerCombinationIds[0].CounterCount);
        int id_2 = int.Parse(formula.FlowerCombinationIds[1].CounterCount);
        int id_3 = int.Parse(formula.FlowerCombinationIds[2].CounterCount);
        int vaseId = formula.VaseId;

        string url_vase;
        string url_1;
        string url_2;
        string url_3;
        if (small)
        {
            url_vase = ImageDataModel.Instance.GetSmallVaseUrl(vaseId);
            url_1 = ImageDataModel.Instance.GetSmallFormulaUrl(id_1, vaseId);
            url_2 = ImageDataModel.Instance.GetSmallFormulaUrl(id_2, vaseId);
            url_3 = ImageDataModel.Instance.GetSmallFormulaUrl(id_3, vaseId);
        }
        else
        {
            url_vase = ImageDataModel.Instance.GetVaseUrl(vaseId);
            url_1 = ImageDataModel.Instance.GetFormulaUrl(id_1, vaseId);
            url_2 = ImageDataModel.Instance.GetFormulaUrl(id_2, vaseId);
            url_3 = ImageDataModel.Instance.GetFormulaUrl(id_3, vaseId);
        }
        cell.loader_succulent.url = "";
        cell.loader_vase.url = url_vase;
        cell.loader_1.url = url_1;
        cell.loader_2.url = url_2;
        cell.loader_3.url = url_3;
    }

    public static void ClearView(common_New.ikeImg cell)
    {
        cell.loader_vase.url = "";
        cell.loader_succulent.url = "";
        cell.loader_1.url = "";
        cell.loader_2.url = "";
        cell.loader_3.url = "";
    }
}