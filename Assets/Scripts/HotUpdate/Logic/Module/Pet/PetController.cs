//using System.Collections;
//using System.Collections.Generic;
//using ADK;
//using protobuf.fight;
//using protobuf.messagecode;
//using protobuf.pets;
//using UnityEngine;

//public class PetController : BaseController<PetController>
//{

//    protected override void InitListeners()
//    {
//        //宠物信息
//        AddNetListener<S_MSG_PET_INFO>((int)MessageCode.S_MSG_PET_INFO, PetInfo);
//        //温泉吸引宠物
//        AddNetListener<S_MSG_PET_DRAW>((int)MessageCode.S_MSG_PET_DRAW, PetDraw);
//        //升级
//        AddNetListener<S_MSG_PET_UPGRADE>((int)MessageCode.S_MSG_PET_UPGRADE, PetUpGrade);
//        //升星
//        AddNetListener<S_MSG_PET_STAR>((int)MessageCode.S_MSG_PET_STAR, PetStar);
//        //升一级
//        AddNetListener<S_MSG_PET_UPGRADE_LEVEL>((int)MessageCode.S_MSG_PET_UPGRADE_LEVEL, PetUpGradeLevel);
//        //碎片兑换宠物
//        AddNetListener<S_MSG_PET_EXCHANGE>((int)MessageCode.S_MSG_PET_EXCHANGE, PetExchange);
//        //宠物上阵
//        AddNetListener<S_MSG_BATTLE_PET>((int)MessageCode.S_MSG_BATTLE_PET, BattlePet);
//    }
//    //宠物信息
//    public void PetInfo(S_MSG_PET_INFO data)
//    {
//        //PetModel.Instance.petsList = data.pets;
//        //DispatchEvent(PetEvent.PetInfo);
//    }
//    public void ReqPetInfo()
//    {
//        //C_MSG_PET_INFO c_MSG_PET_INFO = new C_MSG_PET_INFO();
//        //SendCmd((int)MessageCode.C_MSG_PET_INFO, c_MSG_PET_INFO);
//    }
//    //温泉吸引宠物
//    public void PetDraw(S_MSG_PET_DRAW data)
//    {
//        PetModel.Instance.petsList.AddRange(data.pets);
//        //var dropList = ItemModel.Instance.GetDropData(data.items);
//        PetModel.Instance.petItems = data.items;
//        foreach(var value in data.items)
//        {
//            StorageModel.Instance.AddToStorageByItemId(IDUtil.GetEntityValue(value.itemId), (int)value.num);
//        }
//        StorageModel.Instance.OddToStorageItems(data.costItems);
//        UIManager.Instance.OpenPanel<PetCallView>(UIName.PetCallView);
//        DispatchEvent(PetEvent.PetDraw);
//    }

//    public void ReqPetDraw(uint itemId)
//    {
//        C_MSG_PET_DRAW c_MSG_PET_DRAW = new C_MSG_PET_DRAW();
//        c_MSG_PET_DRAW.itemId = itemId;
//        SendCmd((int)MessageCode.C_MSG_PET_DRAW, c_MSG_PET_DRAW);
//    }
//    //升级
//    public void PetUpGrade(S_MSG_PET_UPGRADE data)
//    {
//        StorageModel.Instance.OddToStorageItems(data.costItems);
//        PetModel.Instance.UpdateLevelup(data.pet);
//        PetModel.Instance.UpdatePet(data.pet);
//        DispatchEvent(PetEvent.PetUpGrade);
//    }

//    public void ReqPetUpGrade(uint petId,uint itemId)
//    {
//        C_MSG_PET_UPGRADE c_MSG_PET_UPGRADE = new C_MSG_PET_UPGRADE();
//        c_MSG_PET_UPGRADE.petId = petId;
//        c_MSG_PET_UPGRADE.itemId = itemId;
//        SendCmd((int)MessageCode.C_MSG_PET_UPGRADE, c_MSG_PET_UPGRADE);
//    }
//    //升星
//    public void PetStar(S_MSG_PET_STAR data)
//    {
//        StorageModel.Instance.OddToStorageItems(data.costItems);
//        PetModel.Instance.UpdatePet(data.pet);
//        DispatchEvent(PetEvent.PetStar);
//    }

//    public void ReqPetStar(uint petId, uint itemId)
//    {
//        C_MSG_PET_STAR c_MSG_PET_STAR = new C_MSG_PET_STAR();
//        c_MSG_PET_STAR.petId = petId;
//        SendCmd((int)MessageCode.C_MSG_PET_STAR, c_MSG_PET_STAR);
//    }
//    //升一级
//    public void PetUpGradeLevel(S_MSG_PET_UPGRADE_LEVEL data)
//    {
//        StorageModel.Instance.OddToStorageItems(data.costItems);
//        PetModel.Instance.UpdateLevelup(data.pet);
//        PetModel.Instance.UpdatePet(data.pet);
//        DispatchEvent(PetEvent.PetUpGrade);
//    }

//    public void ReqPetUpGradeLevel(uint petId)
//    {
//        C_MSG_PET_UPGRADE_LEVEL c_MSG_PET_UPGRADE_LEVEL = new C_MSG_PET_UPGRADE_LEVEL();
//        c_MSG_PET_UPGRADE_LEVEL.petId = petId;
//        SendCmd((int)MessageCode.C_MSG_PET_UPGRADE_LEVEL, c_MSG_PET_UPGRADE_LEVEL);
//    }
//    //碎片兑换宠物
//    public void PetExchange(S_MSG_PET_EXCHANGE data)
//    {
//        StorageModel.Instance.OddToStorageItems(data.costItems);
//        PetModel.Instance.petsList.Add(data.pet);
//        DispatchEvent(PetEvent.PetExchange);
//    }

//    public void ReqPetExchange(uint petId)
//    {
//        C_MSG_PET_EXCHANGE c_MSG_PET_EXCHANGE = new C_MSG_PET_EXCHANGE();
//        c_MSG_PET_EXCHANGE.petId = petId;
//        SendCmd((int)MessageCode.C_MSG_PET_EXCHANGE, c_MSG_PET_EXCHANGE);
//    }
//    //宠物上阵
//    public void BattlePet(S_MSG_BATTLE_PET data)
//    {
//        PlayerModel.Instance.pen.battlePets = data.battlePets;
//        DispatchEvent(PetEvent.BattlePet);
//    }

//    public void ReqBattlePet(uint pos,uint petId)
//    {
//        C_MSG_BATTLE_PET c_MSG_BATTLE_PET = new C_MSG_BATTLE_PET();
//        c_MSG_BATTLE_PET.pos = pos;
//        c_MSG_BATTLE_PET.petId = petId;
//        SendCmd((int)MessageCode.C_MSG_BATTLE_PET, c_MSG_BATTLE_PET);
//    }
//}
