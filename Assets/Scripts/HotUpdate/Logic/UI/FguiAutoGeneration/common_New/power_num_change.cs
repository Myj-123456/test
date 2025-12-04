/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class power_num_change : GComponent
    {
        public Controller status;
        public GImage n3;
        public GTextField power_title;
        public GTextField powerLab;
        public GTextField addLab;
        public GImage n2;
        public GGroup n5;
        public const string URL = "ui://mjiw43v9m3gh1yjp7wi";

        public static power_num_change CreateInstance()
        {
            return (power_num_change)UIPackage.CreateObject("common_New", "power_num_change");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n3 = (GImage)GetChildAt(0);
            power_title = (GTextField)GetChildAt(1);
            powerLab = (GTextField)GetChildAt(2);
            addLab = (GTextField)GetChildAt(3);
            n2 = (GImage)GetChildAt(4);
            n5 = (GGroup)GetChildAt(5);
        }
    }
}