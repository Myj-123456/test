/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class dian_water_item : GComponent
    {
        public Controller status;
        public GImage n8;
        public GTextField tipLab;
        public GLoader bg;
        public GLoader pic;
        public GTextField numLab;
        public GTextField timeLab;
        public GButton get_btn;
        public GButton video_btn;
        public GTextField getLab;
        public const string URL = "ui://dpcxz2fikkb12q";

        public static dian_water_item CreateInstance()
        {
            return (dian_water_item)UIPackage.CreateObject("fun_Scene", "dian_water_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n8 = (GImage)GetChildAt(0);
            tipLab = (GTextField)GetChildAt(1);
            bg = (GLoader)GetChildAt(2);
            pic = (GLoader)GetChildAt(3);
            numLab = (GTextField)GetChildAt(4);
            timeLab = (GTextField)GetChildAt(5);
            get_btn = (GButton)GetChildAt(6);
            video_btn = (GButton)GetChildAt(7);
            getLab = (GTextField)GetChildAt(8);
        }
    }
}