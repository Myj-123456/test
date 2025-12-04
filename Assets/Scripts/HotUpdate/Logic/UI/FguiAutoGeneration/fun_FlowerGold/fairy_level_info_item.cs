/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerGold
{
    public partial class fairy_level_info_item : GComponent
    {
        public Controller status;
        public GImage n1;
        public GTextField lvLab;
        public GTextField limitLab;
        public GTextField skillLab;
        public const string URL = "ui://44kfvb3rm3gh3h";

        public static fairy_level_info_item CreateInstance()
        {
            return (fairy_level_info_item)UIPackage.CreateObject("fun_FlowerGold", "fairy_level_info_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            lvLab = (GTextField)GetChildAt(1);
            limitLab = (GTextField)GetChildAt(2);
            skillLab = (GTextField)GetChildAt(3);
        }
    }
}