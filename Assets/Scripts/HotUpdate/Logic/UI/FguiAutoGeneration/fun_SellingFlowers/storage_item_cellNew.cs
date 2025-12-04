/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_SellingFlowers
{
    public partial class storage_item_cellNew : GButton
    {
        public Controller status;
        public GImage n22;
        public GImage n23;
        public GComponent ikeImg;
        public GTextField count_txt;
        public GTextField nameLab;
        public const string URL = "ui://ztwqlwa2dgpkp3c";

        public static storage_item_cellNew CreateInstance()
        {
            return (storage_item_cellNew)UIPackage.CreateObject("fun_SellingFlowers", "storage_item_cellNew");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n22 = (GImage)GetChildAt(0);
            n23 = (GImage)GetChildAt(1);
            ikeImg = (GComponent)GetChildAt(2);
            count_txt = (GTextField)GetChildAt(3);
            nameLab = (GTextField)GetChildAt(4);
        }
    }
}