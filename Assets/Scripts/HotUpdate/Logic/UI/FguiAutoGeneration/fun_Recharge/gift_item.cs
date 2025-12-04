/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class gift_item : GComponent
    {
        public Controller limit;
        public Controller rare;
        public Controller itemStatus;
        public GImage n13;
        public GImage n18;
        public GImage n24;
        public GImage n25;
        public GImage n14;
        public GTextField rareLab;
        public GTextField rareNum;
        public GTextField limitLab;
        public GTextField timeLab;
        public GTextField nameLab;
        public buy_btn1 buy_btn;
        public reward_item1 item0;
        public reward_item1 item1;
        public reward_item1 item2;
        public reward_item1 item3;
        public const string URL = "ui://w3ox9yltdidl22";

        public static gift_item CreateInstance()
        {
            return (gift_item)UIPackage.CreateObject("fun_Recharge", "gift_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            limit = GetControllerAt(0);
            rare = GetControllerAt(1);
            itemStatus = GetControllerAt(2);
            n13 = (GImage)GetChildAt(0);
            n18 = (GImage)GetChildAt(1);
            n24 = (GImage)GetChildAt(2);
            n25 = (GImage)GetChildAt(3);
            n14 = (GImage)GetChildAt(4);
            rareLab = (GTextField)GetChildAt(5);
            rareNum = (GTextField)GetChildAt(6);
            limitLab = (GTextField)GetChildAt(7);
            timeLab = (GTextField)GetChildAt(8);
            nameLab = (GTextField)GetChildAt(9);
            buy_btn = (buy_btn1)GetChildAt(10);
            item0 = (reward_item1)GetChildAt(11);
            item1 = (reward_item1)GetChildAt(12);
            item2 = (reward_item1)GetChildAt(13);
            item3 = (reward_item1)GetChildAt(14);
        }
    }
}