/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class welfare_main_view : GComponent
    {
        public Controller tab;
        public sign_view sign_view;
        public growth_view growth_view;
        public turntable_view turntable_view;
        public seventh_sign_view seven_view;
        public video_double_view video_view;
        public GList page_list;
        public GButton close_btn;
        public const string URL = "ui://awswhm01g0s00";

        public static welfare_main_view CreateInstance()
        {
            return (welfare_main_view)UIPackage.CreateObject("fun_Welfare", "welfare_main_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            sign_view = (sign_view)GetChildAt(0);
            growth_view = (growth_view)GetChildAt(1);
            turntable_view = (turntable_view)GetChildAt(2);
            seven_view = (seventh_sign_view)GetChildAt(3);
            video_view = (video_double_view)GetChildAt(4);
            page_list = (GList)GetChildAt(5);
            close_btn = (GButton)GetChildAt(6);
        }
    }
}