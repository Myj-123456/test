/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class item_com : GComponent
    {
        public GLoader bg;
        public GLoader pic;
        public GTextField numLab;
        public const string URL = "ui://mjiw43v9kelj1yjp85h";

        public static item_com CreateInstance()
        {
            return (item_com)UIPackage.CreateObject("common_New", "item_com");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            numLab = (GTextField)GetChildAt(2);
        }
    }
}