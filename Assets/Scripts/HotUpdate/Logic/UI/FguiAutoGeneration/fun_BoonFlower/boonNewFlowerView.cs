/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_BoonFlower
{
    public partial class boonNewFlowerView : GComponent
    {
        public Controller status;
        public GLoader bg;
        public GButton close_btn;
        public GButton getBtn1;
        public GButton getBtn2;
        public GButton getBtn3;
        public GTextField congratulationsTxt;
        public GTextField titleTxt;
        public GRichTextField decLab;
        public GRichTextField adTimes;
        public videoBtn video_btn;
        public tabBtn tab1;
        public tabBtn tab2;
        public tabBtn tab3;
        public boonNewFlowerItem item1;
        public boonNewFlowerItem item2;
        public boonNewFlowerItem item3;
        public const string URL = "ui://fsc3a856e0lm7";

        public static boonNewFlowerView CreateInstance()
        {
            return (boonNewFlowerView)UIPackage.CreateObject("fun_BoonFlower", "boonNewFlowerView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            close_btn = (GButton)GetChildAt(1);
            getBtn1 = (GButton)GetChildAt(2);
            getBtn2 = (GButton)GetChildAt(3);
            getBtn3 = (GButton)GetChildAt(4);
            congratulationsTxt = (GTextField)GetChildAt(5);
            titleTxt = (GTextField)GetChildAt(6);
            decLab = (GRichTextField)GetChildAt(7);
            adTimes = (GRichTextField)GetChildAt(8);
            video_btn = (videoBtn)GetChildAt(9);
            tab1 = (tabBtn)GetChildAt(10);
            tab2 = (tabBtn)GetChildAt(11);
            tab3 = (tabBtn)GetChildAt(12);
            item1 = (boonNewFlowerItem)GetChildAt(13);
            item2 = (boonNewFlowerItem)GetChildAt(14);
            item3 = (boonNewFlowerItem)GetChildAt(15);
        }
    }
}