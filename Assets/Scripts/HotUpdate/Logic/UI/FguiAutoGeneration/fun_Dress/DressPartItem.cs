/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class DressPartItem : GComponent
    {
        public Controller unlock;
        public Controller type;
        public GLoader img_quality;
        public GLoader img_icon;
        public GImage n9;
        public GImage n6;
        public GTextField txt_weared;
        public GGroup group_weared;
        public const string URL = "ui://argzn455quk22";

        public static DressPartItem CreateInstance()
        {
            return (DressPartItem)UIPackage.CreateObject("fun_Dress", "DressPartItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            unlock = GetControllerAt(0);
            type = GetControllerAt(1);
            img_quality = (GLoader)GetChildAt(0);
            img_icon = (GLoader)GetChildAt(1);
            n9 = (GImage)GetChildAt(2);
            n6 = (GImage)GetChildAt(3);
            txt_weared = (GTextField)GetChildAt(4);
            group_weared = (GGroup)GetChildAt(5);
        }
    }
}