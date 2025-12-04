/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class blackListItem : GComponent
    {
        public GImage n1;
        public GComponent heead;
        public GComponent picFrame;
        public GImage icon;
        public GTextField txt_lv;
        public GTextField txt_name;
        public GTextField idTxt;
        public GButton btn_remove;
        public const string URL = "ui://fteyf9nzi64u11";

        public static blackListItem CreateInstance()
        {
            return (blackListItem)UIPackage.CreateObject("fun_Friends", "blackListItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            heead = (GComponent)GetChildAt(1);
            picFrame = (GComponent)GetChildAt(2);
            icon = (GImage)GetChildAt(3);
            txt_lv = (GTextField)GetChildAt(4);
            txt_name = (GTextField)GetChildAt(5);
            idTxt = (GTextField)GetChildAt(6);
            btn_remove = (GButton)GetChildAt(7);
        }
    }
}