/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace act_Turntable
{
    public partial class TurntableWindowUI : GComponent
    {
        public Controller platform;
        public GImage n52;
        public GImage count_txtBg;
        public GImage n50;
        public GTextField leftTime_txt;
        public GGroup time_info;
        public GTextField count_txt;
        public GTextField times_txt2;
        public GButton n57;
        public const string URL = "ui://6kz12i2sz9sjqp";

        public static TurntableWindowUI CreateInstance()
        {
            return (TurntableWindowUI)UIPackage.CreateObject("act_Turntable", "TurntableWindowUI");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            platform = GetControllerAt(0);
            n52 = (GImage)GetChildAt(0);
            count_txtBg = (GImage)GetChildAt(1);
            n50 = (GImage)GetChildAt(2);
            leftTime_txt = (GTextField)GetChildAt(3);
            time_info = (GGroup)GetChildAt(4);
            count_txt = (GTextField)GetChildAt(5);
            times_txt2 = (GTextField)GetChildAt(6);
            n57 = (GButton)GetChildAt(7);
        }
    }
}