/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual
{
    public partial class vasePanel : GComponent
    {
        public GList vaseList;
        public GList vase_page_list;
        public GButton vaseRightBtn;
        public GButton vaseLeftBtn;
        public const string URL = "ui://6q8q1ai6ftbu1ayr85f";

        public static vasePanel CreateInstance()
        {
            return (vasePanel)UIPackage.CreateObject("fun_CultivationManual", "vasePanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            vaseList = (GList)GetChildAt(0);
            vase_page_list = (GList)GetChildAt(1);
            vaseRightBtn = (GButton)GetChildAt(2);
            vaseLeftBtn = (GButton)GetChildAt(3);
        }
    }
}