/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerArrangement
{
    public partial class flower_item : GComponent
    {
        public GImage n22;
        public GLoader img_loader;
        public GTextField num;
        public GTextField itemNameTxt;
        public const string URL = "ui://6kofjj39gcv12s";

        public static flower_item CreateInstance()
        {
            return (flower_item)UIPackage.CreateObject("fun_FlowerArrangement", "flower_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n22 = (GImage)GetChildAt(0);
            img_loader = (GLoader)GetChildAt(1);
            num = (GTextField)GetChildAt(2);
            itemNameTxt = (GTextField)GetChildAt(3);
        }
    }
}