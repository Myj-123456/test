/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_OrderFlower
{
    public partial class getReward_item : GComponent
    {
        public Controller type;
        public GLoader bg;
        public GLoader pic;
        public GImage n8;
        public GTextField txt_add;
        public GTextField txt_title;
        public GGroup n13;
        public GTextField txt_name;
        public GTextField txt_num;
        public const string URL = "ui://ypcg4u88eqnf1yjp7sb";

        public static getReward_item CreateInstance()
        {
            return (getReward_item)UIPackage.CreateObject("fun_OrderFlower", "getReward_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            n8 = (GImage)GetChildAt(2);
            txt_add = (GTextField)GetChildAt(3);
            txt_title = (GTextField)GetChildAt(4);
            n13 = (GGroup)GetChildAt(5);
            txt_name = (GTextField)GetChildAt(6);
            txt_num = (GTextField)GetChildAt(7);
        }
    }
}