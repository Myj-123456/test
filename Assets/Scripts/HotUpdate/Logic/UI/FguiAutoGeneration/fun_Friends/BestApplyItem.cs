/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class BestApplyItem : GComponent
    {
        public Controller txtcontroller;
        public GImage n1;
        public GComponent heead;
        public GComponent picFrame;
        public GImage icon;
        public GTextField txt_lv;
        public GTextField txt_name;
        public GTextField idTxt;
        public GButton btn_newApply;
        public GTextField Text_time;
        public GTextField Text_unLevel;
        public GTextField Text_unAgree;
        public const string URL = "ui://fteyf9nzg3sj1yjp7tu";

        public static BestApplyItem CreateInstance()
        {
            return (BestApplyItem)UIPackage.CreateObject("fun_Friends", "BestApplyItem");
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
            btn_newApply = (GButton)GetChildAt(7);
            Text_time = (GTextField)GetChildAt(8);
            Text_unLevel = (GTextField)GetChildAt(9);
            Text_unAgree = (GTextField)GetChildAt(10);
        }
    }
}