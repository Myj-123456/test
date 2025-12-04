/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class btn_flower_sort : GButton
    {
        public Controller status;
        public Controller c1;
        public GImage n6;
        public GImage n7;
        public GTextField n11;
        public GTextField n12;
        public const string URL = "ui://dpcxz2fiowcx11";

        public static btn_flower_sort CreateInstance()
        {
            return (btn_flower_sort)UIPackage.CreateObject("fun_Scene", "btn_flower_sort");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            c1 = GetControllerAt(1);
            n6 = (GImage)GetChildAt(0);
            n7 = (GImage)GetChildAt(1);
            n11 = (GTextField)GetChildAt(2);
            n12 = (GTextField)GetChildAt(3);
        }
    }
}