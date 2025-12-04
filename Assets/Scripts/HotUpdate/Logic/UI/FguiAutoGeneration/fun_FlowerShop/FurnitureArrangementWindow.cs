/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerShop
{
    public partial class FurnitureArrangementWindow : GComponent
    {
        public GLoader n2;
        public GImage n3;
        public GList list_part;
        public GTextField txt_noDress;
        public GList list_filter;
        public GButton close_btn;
        public GButton btn_confirm;
        public GGroup group_bottom;
        public const string URL = "ui://4nb2f1z8frbs0";

        public static FurnitureArrangementWindow CreateInstance()
        {
            return (FurnitureArrangementWindow)UIPackage.CreateObject("fun_FlowerShop", "FurnitureArrangementWindow");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GLoader)GetChildAt(0);
            n3 = (GImage)GetChildAt(1);
            list_part = (GList)GetChildAt(2);
            txt_noDress = (GTextField)GetChildAt(3);
            list_filter = (GList)GetChildAt(4);
            close_btn = (GButton)GetChildAt(5);
            btn_confirm = (GButton)GetChildAt(6);
            group_bottom = (GGroup)GetChildAt(7);
        }
    }
}