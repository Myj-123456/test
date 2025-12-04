/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class DressPartItem1 : GComponent
    {
        public Controller unlock;
        public GLoader img_quality;
        public GLoader img_icon;
        public GImage n11;
        public GImage n9;
        public const string URL = "ui://argzn455hstt1yjp83e";

        public static DressPartItem1 CreateInstance()
        {
            return (DressPartItem1)UIPackage.CreateObject("fun_Dress", "DressPartItem1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            unlock = GetControllerAt(0);
            img_quality = (GLoader)GetChildAt(0);
            img_icon = (GLoader)GetChildAt(1);
            n11 = (GImage)GetChildAt(2);
            n9 = (GImage)GetChildAt(3);
        }
    }
}