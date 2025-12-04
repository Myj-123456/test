/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class topBtns : GComponent
    {
        public GLoader loader_headIcon;
        public GComponent frame;
        public goldBar goldBar;
        public diamandBar diamandBar;
        public waterBar waterBar;
        public levelBar levelBar;
        public const string URL = "ui://fa0hi8ybfm3f15";

        public static topBtns CreateInstance()
        {
            return (topBtns)UIPackage.CreateObject("fun_MainUI", "topBtns");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            loader_headIcon = (GLoader)GetChildAt(0);
            frame = (GComponent)GetChildAt(1);
            goldBar = (goldBar)GetChildAt(2);
            diamandBar = (diamandBar)GetChildAt(3);
            waterBar = (waterBar)GetChildAt(4);
            levelBar = (levelBar)GetChildAt(5);
        }
    }
}