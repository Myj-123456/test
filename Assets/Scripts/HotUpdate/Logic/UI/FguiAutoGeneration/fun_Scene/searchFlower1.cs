/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class searchFlower1 : GComponent
    {
        public GImage n7;
        public btn_search1 btn_search;
        public GTextInput input_search;
        public const string URL = "ui://dpcxz2fih3ye3p";

        public static searchFlower1 CreateInstance()
        {
            return (searchFlower1)UIPackage.CreateObject("fun_Scene", "searchFlower1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n7 = (GImage)GetChildAt(0);
            btn_search = (btn_search1)GetChildAt(1);
            input_search = (GTextInput)GetChildAt(2);
        }
    }
}