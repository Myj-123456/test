/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class btn_flower_sort1 : GButton
    {
        public Controller status;
        public Controller c1;
        public GImage n14;
        public GImage n15;
        public GImage n16;
        public GImage n17;
        public GTextField n11;
        public GTextField n12;
        public const string URL = "ui://dpcxz2fih3ye3k";

        public static btn_flower_sort1 CreateInstance()
        {
            return (btn_flower_sort1)UIPackage.CreateObject("fun_Scene", "btn_flower_sort1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            c1 = GetControllerAt(1);
            n14 = (GImage)GetChildAt(0);
            n15 = (GImage)GetChildAt(1);
            n16 = (GImage)GetChildAt(2);
            n17 = (GImage)GetChildAt(3);
            n11 = (GTextField)GetChildAt(4);
            n12 = (GTextField)GetChildAt(5);
        }
    }
}