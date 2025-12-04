/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class ViballsBubbleItem : GComponent
    {
        public GImage n0;
        public GLoader img_icon;
        public GTextField txt_num;
        public const string URL = "ui://dpcxz2figxulu";

        public static ViballsBubbleItem CreateInstance()
        {
            return (ViballsBubbleItem)UIPackage.CreateObject("fun_Scene", "ViballsBubbleItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            img_icon = (GLoader)GetChildAt(1);
            txt_num = (GTextField)GetChildAt(2);
        }
    }
}