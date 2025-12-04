/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerGold
{
    public partial class fairy_level_info_view : GComponent
    {
        public GImage n2;
        public GLoader bg;
        public GImage n65;
        public GButton close_btn;
        public GList list;
        public const string URL = "ui://44kfvb3rm3gh3e";

        public static fairy_level_info_view CreateInstance()
        {
            return (fairy_level_info_view)UIPackage.CreateObject("fun_FlowerGold", "fairy_level_info_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n65 = (GImage)GetChildAt(2);
            close_btn = (GButton)GetChildAt(3);
            list = (GList)GetChildAt(4);
        }
    }
}