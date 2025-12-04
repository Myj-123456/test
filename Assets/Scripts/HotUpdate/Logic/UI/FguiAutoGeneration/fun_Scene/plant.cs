/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class plant : GComponent
    {
        public Controller status;
        public GTextField placeholder;
        public GTextField tipLab;
        public GImage n31;
        public GGroup n25;
        public const string URL = "ui://dpcxz2fip0sc27";

        public static plant CreateInstance()
        {
            return (plant)UIPackage.CreateObject("fun_Scene", "plant");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            placeholder = (GTextField)GetChildAt(0);
            tipLab = (GTextField)GetChildAt(1);
            n31 = (GImage)GetChildAt(2);
            n25 = (GGroup)GetChildAt(3);
        }
    }
}