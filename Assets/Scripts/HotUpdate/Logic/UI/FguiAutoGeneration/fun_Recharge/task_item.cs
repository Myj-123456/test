/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class task_item : GComponent
    {
        public Controller status;
        public GImage n14;
        public item_com cell;
        public GRichTextField tipLab;
        public GButton getBtn;
        public GButton goBtn;
        public GImage n20;
        public pro pro;
        public GTextField proLab;
        public const string URL = "ui://w3ox9yltin5z1yjp873";

        public static task_item CreateInstance()
        {
            return (task_item)UIPackage.CreateObject("fun_Recharge", "task_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n14 = (GImage)GetChildAt(0);
            cell = (item_com)GetChildAt(1);
            tipLab = (GRichTextField)GetChildAt(2);
            getBtn = (GButton)GetChildAt(3);
            goBtn = (GButton)GetChildAt(4);
            n20 = (GImage)GetChildAt(5);
            pro = (pro)GetChildAt(6);
            proLab = (GTextField)GetChildAt(7);
        }
    }
}