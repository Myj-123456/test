/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class FlowerTableItem : GComponent
    {
        public GComponent ike;
        public GTextField txxTime;
        public const string URL = "ui://dpcxz2fij0w82";

        public static FlowerTableItem CreateInstance()
        {
            return (FlowerTableItem)UIPackage.CreateObject("fun_Scene", "FlowerTableItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            ike = (GComponent)GetChildAt(0);
            txxTime = (GTextField)GetChildAt(1);
        }
    }
}