/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class btn_search1 : GButton
    {
        public GImage n1;
        public const string URL = "ui://dpcxz2fih3ye3r";

        public static btn_search1 CreateInstance()
        {
            return (btn_search1)UIPackage.CreateObject("fun_Scene", "btn_search1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
        }
    }
}