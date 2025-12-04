/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_plant
{
    public partial class buy_jia_item : GButton
    {
        public Controller button;
        public GImage n1;
        public GImage n8;
        public GImage n3;
        public GTextField txt_title;
        public GTextField txt_cost;
        public GLoader costImg;
        public GTextField costLab;
        public GTextField limitLab;
        public const string URL = "ui://qfpad3q0tewh13";

        public static buy_jia_item CreateInstance()
        {
            return (buy_jia_item)UIPackage.CreateObject("fun_Guild_plant", "buy_jia_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            n8 = (GImage)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            txt_title = (GTextField)GetChildAt(3);
            txt_cost = (GTextField)GetChildAt(4);
            costImg = (GLoader)GetChildAt(5);
            costLab = (GTextField)GetChildAt(6);
            limitLab = (GTextField)GetChildAt(7);
        }
    }
}