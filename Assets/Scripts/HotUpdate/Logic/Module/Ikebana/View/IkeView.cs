
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using System;
using Elida.Config;

public class IkeView : BaseView
{
    private fun_FlowerArrangement.ikeView viewSkin;

    private fun_FlowerArrangement.ikeView view_;

    /**
    * 当前选中的花瓶数据
    */
    private StaticFlowerPoint _vaseData;

    /**
    * 当前花瓶显示页
    */
    private int _currentVase;

    /**
    * 花瓶种类数（静态表配置）
    */
    private int _vaseNum;

    /**
    * 当前选中的插槽
    */
    private int _select;
    /**
    * 插花材料数据
    */
    private List<StaticFlower> _flowerList;


    /**
     * 插槽1所选材料
     */
    private StaticFlower _selectFlower_1;

    /**
    * 插槽2所选材料
    */
    private StaticFlower _selectFlower_2;

    /**
    * 插槽3所选材料
    */
    private StaticFlower _selectFlower_3;

    private StaticFormula currentFormula;

    private int newMakeNum = 0;

    //private StaticSucculentIke _selectFormula;

    private int[] _flowerClues;

    public NpcOrderVO openOrder;

    public IkeView()
    {
        packageName = "fun_FlowerArrangement";
        // 设置委托
        BindAllDelegate = fun_FlowerArrangement.fun_FlowerArrangementBinder.BindAll;
        CreateInstanceDelegate = fun_FlowerArrangement.ikeView.CreateInstance;


    }

    public override void OnInit()
    {
        base.OnInit();
        viewSkin = ui as fun_FlowerArrangement.ikeView;
        view_ = viewSkin;
        view_.txt_price.text = Lang.GetValue("sell_lab");//售价：

        view_.titleLab.text = Lang.GetValue("ike_view_1");



        SetBg(view_.bg, "Ike/ELIDA_chahuan_cjbg01.jpg");

        view_.txt_num.text = "1";
        ShowSpine();
        view_.btn_add.onClick.Add(OnNumBtnClick);
        view_.btn_minus.onClick.Add(OnNumBtnClick);

        view_.tweenCom.flower.list.itemRenderer = RenderItem;
        view_.tweenCom.flower.list.onClickItem.Add((EventContext context) =>
        {
            int index = (int)(context.data as fun_FlowerArrangement.flower_item).data;
            StaticFlower vo = _flowerList[index];
            Module_item_defConfig item = ItemModel.Instance.GetItemById(vo.FlowersDI);
            if (_select == 1)
            {
                _selectFlower_1 = vo;
                view_.ike.flower_1.url = ImageDataModel.Instance.GetFormulaUrl(item.ItemDefId, _vaseData.VaseId);
                view_.ike.flower_1_effect.Play();

            }
            else if (_select == 2)
            {
                _selectFlower_2 = vo;
                view_.ike.flower_2.url = ImageDataModel.Instance.GetFormulaUrl(item.ItemDefId, _vaseData.VaseId);
                view_.ike.flower_2_effect.Play();

            }
            else if (_select == 3)
            {
                _selectFlower_3 = vo;
                view_.ike.flower_3.url = ImageDataModel.Instance.GetFormulaUrl(item.ItemDefId, _vaseData.VaseId);
                view_.ike.flower_3_effect.Play();
            }
            if (_selectFlower_1 != null && _selectFlower_2 != null && _selectFlower_3 != null)
            {
                //view_.showFlower.selectedIndex = 0;
                ClosePlay();
                currentFormula = IkeModel.Instance.GetFormulaData(_selectFlower_1.FlowersDI, _selectFlower_2.FlowersDI, _selectFlower_3.FlowersDI, _vaseData.VaseId);
                ShowIkeItem(currentFormula);
                newMakeNum = 1;
                setBtn_makeEnable();

                if (currentFormula != null)
                {
                    view_.Txt_gold.text = TextUtil.ChangeCoinShow(CalculatePrice());
                }
            }
            else
            {
                view_.btn_add.enabled = view_.btn_minus.enabled = false;
            }



        });

        view_.btn_make.onClick.Add(() =>
        {
            IkeController.Instance.ResIkebanaMake((uint)currentFormula.CombinationId, (uint)newMakeNum);
        });

        view_.btn_right.onClick.Add(() =>
        {
            _currentVase++;
            if (_currentVase >= _vaseNum)
            {
                _currentVase = 0;
            }
            view_.showFlower.selectedIndex = 0;
            UpdateData();
            ShowVase();
            newMakeNum = 1;
            //setBtn_makeEnable();
            SetAddBtnSelected(0);
        });

        view_.btn_left.onClick.Add(() =>
        {
            _currentVase--;
            if (_currentVase < 0)
            {
                _currentVase = _vaseNum - 1;
            }
            view_.showFlower.selectedIndex = 0;
            UpdateData();
            ShowVase();
            newMakeNum = 1;
            //setBtn_makeEnable();
            SetAddBtnSelected(0);
        });

        view_.btn_select_1.onClick.Add(() =>
        {
            //view_.showFlower.selectedIndex = 1;
            ShowPlay();
            _select = 1;
            SetAddBtnSelected(1);
            UpdataFlowerList();

        });

        view_.btn_select_2.onClick.Add(() =>
        {
            //view_.showFlower.selectedIndex = 1;
            ShowPlay();
            _select = 2;
            SetAddBtnSelected(2);
            UpdataFlowerList();

        });

        view_.btn_select_3.onClick.Add(() =>
        {
            //view_.showFlower.selectedIndex = 1;
            ShowPlay();
            _select = 3;
            SetAddBtnSelected(3);
            UpdataFlowerList();

        });

        view_.input_area.onClick.Add(() =>
        {
            string title = Lang.GetValue("slang_133");//请输入数量
            string eventName = IkebanaEvent.IkeUpdateCount;
            object[] param = new object[] { title, eventName };
            UIManager.Instance.OpenWindow<GuildInputWindow>(UIName.GuildInputWindow, param);
        });

        AddEventListener(IkebanaEvent.IkebanaMake, UpdateData);
        AddEventListener<string>(IkebanaEvent.IkeUpdateCount, UpdateNum);
    }

    private void ShowSpine()
    {
        view_.loader_spine.loop = true;
        view_.loader_spine.url = "laobannian";
        view_.loader_spine.animationName = "animation";
    }

    private void ShowPlay()
    {
        if (view_.showFlower.selectedIndex == 0)
        {
            view_.showFlower.selectedIndex = 1;
            view_.touchable = false;
            view_.tweenCom.left.Play(() =>
            {
                view_.touchable = true;
            });
            view_.tweenCom.flower.open.Play();
        }
    }

    private void ClosePlay()
    {
        if (view_.showFlower.selectedIndex == 1)
        {

            view_.touchable = false;
            view_.tweenCom.right.Play(() =>
            {
                view_.showFlower.selectedIndex = 0;
                view_.touchable = true;
            });
            view_.tweenCom.flower.close.Play();
        }
    }

    public override void OnShown()
    {
        base.OnShown();


        // 其他打开面板的逻辑
        _vaseNum = IkeModel.Instance.staticFlowerPointList.Count;
        view_.btn_add.enabled = view_.btn_minus.enabled = false;
        openOrder = null;

        view_.txt_num.text = "1";
        _currentVase = 0;
        SetAddBtnSelected(0);
        OpenIkeParam param = data as OpenIkeParam;
        if (param != null)
        {
            if (param.vaseId > 0)
            {
                SetCurrentVase(param.vaseId);
            }
            if (param.formulaId > 0)
            {
                _flowerClues = IkeModel.Instance.GetFlowerListByDemandItem(param.formulaId);
            }
            if (param.npcOrderVO != null)
            {
                openOrder = param.npcOrderVO;
            }
        }
        if (view_.type.selectedIndex == 0)
        {
            Clear();
            ShowVase();
            view_.showFlower.selectedIndex = 0;
            view_.btn_right.enabled = _vaseNum > 1;
            view_.btn_left.enabled = view_.btn_right.enabled;
        }
        InitNpcOrder();


    }


    public void InitNpcOrder()
    {
        if (openOrder == null || _flowerClues == null) return;
        for (int i = 0; i < _flowerClues.Length; i++)
        {
            var item = ItemModel.Instance.GetItemById(_flowerClues[i]);
            var vo = IkeModel.Instance.GetFlower(_flowerClues[i]);
            if (i == 0)
            {
                _selectFlower_1 = vo;
                view_.ike.flower_1.url = ImageDataModel.Instance.GetFormulaUrl(item.ItemDefId, _vaseData.VaseId);
                view_.ike.flower_1_effect.Play();
            }
            else if (i == 1)
            {
                _selectFlower_2 = vo;
                view_.ike.flower_2.url = ImageDataModel.Instance.GetFormulaUrl(item.ItemDefId, _vaseData.VaseId);
                view_.ike.flower_2_effect.Play();
            }
            else if (i == 2)
            {
                _selectFlower_3 = vo;
                view_.ike.flower_3.url = ImageDataModel.Instance.GetFormulaUrl(item.ItemDefId, _vaseData.VaseId);
                view_.ike.flower_3_effect.Play();
            }
        }
        if (_selectFlower_1 != null && _selectFlower_2 != null && _selectFlower_3 != null)
        {
            view_.showFlower.selectedIndex = 0;
            currentFormula = IkeModel.Instance.GetFormulaData(_selectFlower_1.FlowersDI, _selectFlower_2.FlowersDI, _selectFlower_3.FlowersDI, _vaseData.VaseId);
            ShowIkeItem(currentFormula);
            newMakeNum = (int)openOrder.ratio;
            setBtn_makeEnable();
            if (currentFormula != null)
            {
                view_.Txt_gold.text = TextUtil.ChangeCoinShow(CalculatePrice());
            }
        }
        else
        {
            view_.btn_add.enabled = view_.btn_minus.enabled = false;
        }
    }

    private void UpdateData()
    {
        Clear();
        newMakeNum = 1;
        view_.showFlower.selectedIndex = 0;
        view_.btn_add.enabled = view_.btn_minus.enabled = false;
        view_.txt_num.text = "1";
        SetAddBtnSelected(0);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
        if (openOrder != null && openOrder.orderId != 0)
        {
            UIManager.Instance.OpenWindow<NpcOrderWindow>(UIName.NpcOrderWindow, openOrder);
        }

    }

    private void SetCurrentVase(int vaseId)
    {
        for (int i = 0; i < IkeModel.Instance.staticFlowerPointList.Count; i++)
        {
            if (vaseId == IkeModel.Instance.staticFlowerPointList[i].VaseId)
            {
                _currentVase = i;
                break;
            }
        }
    }

    public void ShowVase()
    {
        _vaseData = IkeModel.Instance.staticFlowerPointList[_currentVase];
        Module_item_defConfig item = ItemModel.Instance.GetItemById(_vaseData.VaseId);
        if (int.Parse(_vaseData.Leve) > MyselfModel.Instance.level)
        {
            view_.ike.state.selectedIndex = 1;
            view_.ike.Txt_unlock_lv.text = Lang.GetValue("slang_35", _vaseData.Leve);//{0}级解锁
            view_.unlock.selectedIndex = 0;
        }
        else
        {
            view_.ike.state.selectedIndex = 0;
            view_.unlock.selectedIndex = 1;
        }
        view_.ike.vase.url = ImageDataModel.Instance.GetVaseUrl(item.ItemDefId);
    }

    public void Clear()
    {
        currentFormula = null;

        _selectFlower_1 = _selectFlower_2 = _selectFlower_3 = null;

        view_.ike.flower_1_effect.Stop();

        view_.ike.flower_2_effect.Stop();

        view_.ike.flower_3_effect.Stop();

        view_.btn_make.enabled = false;

        view_.ike.flower_1.url = view_.ike.flower_2.url = view_.ike.flower_3.url = "";

        view_.materialList.flower_1.img_loader.url =
                view_.materialList.flower_1.num.text = "";

        view_.materialList.flower_2.img_loader.url =
            view_.materialList.flower_2.num.text = "";

        view_.materialList.flower_3.img_loader.url =
            view_.materialList.flower_3.num.text = "";

        view_.materialList.flower_4.img_loader.url =
            view_.materialList.flower_4.num.text = "";
        view_.priceGp.visible = false;
        view_.showNeed.visible = false;
        view_.Txt_gold.text = "";
    }

    private void UpdataFlowerList()
    {
        if (_flowerList == null)
        {
            _flowerList = new List<StaticFlower>();
        }
        else
        {
            _flowerList.Clear();
        }
        _flowerList = IkeModel.Instance.GetFlowerBySlot(_select, _vaseData.VaseId);
        view_.tweenCom.flower.list.numItems = _flowerList.Count;
    }

    private void RenderItem(int index, GObject item)
    {
        fun_FlowerArrangement.flower_item cell = item as fun_FlowerArrangement.flower_item;
        StaticFlower vo = _flowerList[index];

        cell.data = index;
        Module_item_defConfig itemData = ItemModel.Instance.GetItemById(vo.FlowersDI);
        cell.img_loader.url = ImageDataModel.Instance.GetIconUrl(itemData);
        cell.itemNameTxt.text = Lang.GetValue(itemData.Name);
        cell.num.text = StorageModel.Instance.GetItemCount(vo.FlowersDI).ToString();
    }

    private int CalculatePrice()
    {
        view_.priceGp.visible = true;
        view_.showNeed.visible = true;
        if (currentFormula != null)
        {
            //StaticFlowerSell sell = FlowerShopModel.Instance.staticFlowerSell[currentFormula.IkebanaId];
            return currentFormula.SellPrice * this.newMakeNum;
        }
        return 0;
    }

    private void ShowIkeItem(StaticFormula formula)
    {
        for (int i = 0; i < formula.FlowerCombinationIds.Count; i++)
        {
            Module_item_defConfig item = ItemModel.Instance.GetItemByEntityID(formula.FlowerCombinationIds[i].CounterCount);
            int total = StorageModel.Instance.GetItemCount(item.ItemDefId);
            fun_FlowerArrangement.materiel_itemNew ui = view_.materialList.GetChildAt(i) as fun_FlowerArrangement.materiel_itemNew;
            ui.img_loader.url = ImageDataModel.Instance.GetIconUrl(item);
            UILogicUtils.SetItemShow(ui, item.ItemDefId);
            ui.num.text = UILogicUtils.GetUBBSting(total, formula.FlowerCombinationIds[i].Limit, "#ff0000", "#fff600");
        }

    }

    private void OnNumBtnClick(EventContext context)
    {
        if (_selectFlower_1 == null && _selectFlower_2 == null && _selectFlower_3 == null && view_.type.selectedIndex == 0)
        {
            return;
        }
        int addNum = context.sender == view_.btn_add ? 1 : -1;
        int newNum_ = newMakeNum + addNum;
        newNum_ = newNum_ < 1 ? 1 : newNum_;
        newMakeNum = newNum_;
        setBtn_makeEnable();
    }

    private void UpdateNum(string num)
    {
        if (_selectFlower_1 == null && _selectFlower_2 == null && _selectFlower_3 == null && view_.type.selectedIndex == 0)
        {
            return;
        }
        newMakeNum = int.Parse(num);
        setBtn_makeEnable();

    }

    private void setBtn_makeEnable(int type = 0)
    {
        if (type == 1)
        {
            return;
        }

        int count_1 = GetFlowerCount(_selectFlower_1);
        int count_2 = GetFlowerCount(_selectFlower_2);
        int count_3 = GetFlowerCount(_selectFlower_3);
        int min_ = Math.Min(count_1, Math.Min(count_2, count_3));
        if (newMakeNum + 1 > min_)
        {
            view_.btn_add.enabled = false;
            newMakeNum = min_ == 0 ? 1 : min_;
        }
        else
        {
            view_.btn_add.enabled = true;
        }

        if (count_1 < 1 || count_2 < 1 || count_3 < 1 || count_1 < currentFormula.FlowerCombinationIds[0].Limit * newMakeNum ||
             count_2 < currentFormula.FlowerCombinationIds[1].Limit * newMakeNum || count_3 < currentFormula.FlowerCombinationIds[2].Limit)
        {
            view_.btn_make.enabled = false;
        }
        else
        {
            view_.btn_make.enabled = true;
        }
        //设置出售价格
        if (currentFormula != null)
        {
            view_.Txt_gold.text = TextUtil.ChangeCoinShow(CalculatePrice());
        }
        view_.btn_minus.enabled = newMakeNum > 1;
        view_.txt_num.text = newMakeNum + "";
    }

    public int GetFlowerCount(StaticFlower flower)
    {
        return StorageModel.Instance.GetItemCount(flower.FlowersDI);
    }

    private void SetAddBtnSelected(int _tag)
    {  /*#新增Fun 选中的按钮 显示光圈*/
        for (int i = 1; i <= 3; i++)
        {
            string str = "btn_select_" + i;
            if (_tag == i)
            {
                (view_.GetChild(str) as fun_FlowerArrangement.add).c1.SetSelectedIndex(1);
            }
            else
            {
                (view_.GetChild(str) as fun_FlowerArrangement.add).c1.SetSelectedIndex(0);
            }
        }
    }
}

