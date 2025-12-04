/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_loading
{
    public partial class LoadingViewUI : GComponent
    {
        public GImage bg;
        public GLoader img_ageTips;
        public GTextField n8;
        public GTextField n9;
        public ProgressBar progressBar;
        public GTextField txt_des;
        public GImage n11;
        public GImage n12;
        public GTextField txt_progress;
        public GGroup n14;
        public GTextField txt_gameVer;
        public const string URL = "ui://t3mkt5pwoyy15";

        public static LoadingViewUI CreateInstance()
        {
            return (LoadingViewUI)UIPackage.CreateObject("fun_loading", "LoadingViewUI");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GImage)GetChildAt(0);
            img_ageTips = (GLoader)GetChildAt(1);
            n8 = (GTextField)GetChildAt(2);
            n9 = (GTextField)GetChildAt(3);
            progressBar = (ProgressBar)GetChildAt(4);
            txt_des = (GTextField)GetChildAt(5);
            n11 = (GImage)GetChildAt(6);
            n12 = (GImage)GetChildAt(7);
            txt_progress = (GTextField)GetChildAt(8);
            n14 = (GGroup)GetChildAt(9);
            txt_gameVer = (GTextField)GetChildAt(10);
        }
    }
}