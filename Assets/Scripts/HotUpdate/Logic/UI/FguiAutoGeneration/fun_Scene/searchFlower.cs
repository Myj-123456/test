/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class searchFlower : GComponent
    {
        public GImage n0;
        public btn_search btn_search;
        public GTextInput input_search;
        public const string URL = "ui://dpcxz2fiqgju23";

        public static searchFlower CreateInstance()
        {
            return (searchFlower)UIPackage.CreateObject("fun_Scene", "searchFlower");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            btn_search = (btn_search)GetChildAt(1);
            input_search = (GTextInput)GetChildAt(2);
        }
    }
}