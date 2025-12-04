/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class Item_flower_need : GComponent
    {
        public GLoader bg;
        public GLoader pic;
        public GRichTextField numLab;
        public GTextField nameLab;
        public const string URL = "ui://mjiw43v9didl1yjp7wp";

        public static Item_flower_need CreateInstance()
        {
            return (Item_flower_need)UIPackage.CreateObject("common_New", "Item_flower_need");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            numLab = (GRichTextField)GetChildAt(2);
            nameLab = (GTextField)GetChildAt(3);
        }
    }
}