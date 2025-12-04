/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class btn_search : GButton
    {
        public GImage n0;
        public const string URL = "ui://dpcxz2fijpt95";

        public static btn_search CreateInstance()
        {
            return (btn_search)UIPackage.CreateObject("fun_Scene", "btn_search");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
        }
    }
}