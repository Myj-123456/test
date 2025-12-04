/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class FlowerTableIGoldItem : GComponent
    {
        public GImage n2;
        public GTextField txtNum;
        public const string URL = "ui://dpcxz2fife264";

        public static FlowerTableIGoldItem CreateInstance()
        {
            return (FlowerTableIGoldItem)UIPackage.CreateObject("fun_Scene", "FlowerTableIGoldItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
            txtNum = (GTextField)GetChildAt(1);
        }
    }
}