/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class fun_MainView : GComponent
    {
        public power_show power;
        public topBtns topBtns;
        public leftBtns leftBtns;
        public rightBtns rightBtns;
        public task_com task_btn;
        public bottomBtns bottomBtns;
        public GComponent ui_chooseFlower;
        public const string URL = "ui://fa0hi8ybfm3f0";

        public static fun_MainView CreateInstance()
        {
            return (fun_MainView)UIPackage.CreateObject("fun_MainUI", "fun_MainView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            power = (power_show)GetChildAt(0);
            topBtns = (topBtns)GetChildAt(1);
            leftBtns = (leftBtns)GetChildAt(2);
            rightBtns = (rightBtns)GetChildAt(3);
            task_btn = (task_com)GetChildAt(4);
            bottomBtns = (bottomBtns)GetChildAt(5);
            ui_chooseFlower = (GComponent)GetChildAt(6);
        }
    }
}