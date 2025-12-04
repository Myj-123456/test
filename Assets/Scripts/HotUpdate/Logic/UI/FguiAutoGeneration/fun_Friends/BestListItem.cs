/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class BestListItem : GComponent
    {
        public Controller txtcontroller;
        public GImage n1;
        public GComponent heead;
        public GComponent picFrame;
        public GImage icon;
        public GTextField txt_lv;
        public GTextField txt_name;
        public GTextField idTxt;
        public GButton btn_Agree;
        public GButton btn_refuse;
        public GTextField Text_Agree;
        public GTextField Text_refuse;
        public const string URL = "ui://fteyf9nzg3sj1yjp7tm";

        public static BestListItem CreateInstance()
        {
            return (BestListItem)UIPackage.CreateObject("fun_Friends", "BestListItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            txtcontroller = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            heead = (GComponent)GetChildAt(1);
            picFrame = (GComponent)GetChildAt(2);
            icon = (GImage)GetChildAt(3);
            txt_lv = (GTextField)GetChildAt(4);
            txt_name = (GTextField)GetChildAt(5);
            idTxt = (GTextField)GetChildAt(6);
            btn_Agree = (GButton)GetChildAt(7);
            btn_refuse = (GButton)GetChildAt(8);
            Text_Agree = (GTextField)GetChildAt(9);
            Text_refuse = (GTextField)GetChildAt(10);
        }
    }
}