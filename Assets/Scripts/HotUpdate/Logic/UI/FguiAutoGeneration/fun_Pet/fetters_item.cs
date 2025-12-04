/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Pet
{
    public partial class fetters_item : GComponent
    {
        public Controller active;
        public GImage n1;
        public GImage n5;
        public GImage n6;
        public GTextField nameLab;
        public GTextField attrLab;
        public GList petList;
        public const string URL = "ui://o7kmyysdx92md";

        public static fetters_item CreateInstance()
        {
            return (fetters_item)UIPackage.CreateObject("fun_Pet", "fetters_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            active = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            n5 = (GImage)GetChildAt(1);
            n6 = (GImage)GetChildAt(2);
            nameLab = (GTextField)GetChildAt(3);
            attrLab = (GTextField)GetChildAt(4);
            petList = (GList)GetChildAt(5);
        }
    }
}