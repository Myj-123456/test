/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class ItemGridTip : GComponent
    {
        public GImage n0;
        public GTextField txt_name;
        public const string URL = "ui://mjiw43v9tosm1yjp7sk";

        public static ItemGridTip CreateInstance()
        {
            return (ItemGridTip)UIPackage.CreateObject("common_New", "ItemGridTip");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            txt_name = (GTextField)GetChildAt(1);
        }
    }
}