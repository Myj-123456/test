/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Plot
{
    public partial class plot_main_View : GComponent
    {
        public main_content main;
        public GImage n1;
        public GButton close_btn;
        public const string URL = "ui://vucpfjl8accs1yjp82r";

        public static plot_main_View CreateInstance()
        {
            return (plot_main_View)UIPackage.CreateObject("fun_Plot", "plot_main_View");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            main = (main_content)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            close_btn = (GButton)GetChildAt(2);
        }
    }
}