/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_plant
{
    public partial class plant_handle : GComponent
    {
        public Controller status;
        public GGraph bg;
        public btn_shovel bt_cc;
        public btn_shovelAll bt_cc_all;
        public btn_speedup bt_js;
        public btn_speedupAll bt_js_all;
        public c_timeDown com_timeDown;
        public c_residue com_residue;
        public btn_video btn_video;
        public btn_free_speed free_speed;
        public const string URL = "ui://4905g7p7nwd51g";

        public static plant_handle CreateInstance()
        {
            return (plant_handle)UIPackage.CreateObject("fun_plant", "plant_handle");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            bg = (GGraph)GetChildAt(0);
            bt_cc = (btn_shovel)GetChildAt(1);
            bt_cc_all = (btn_shovelAll)GetChildAt(2);
            bt_js = (btn_speedup)GetChildAt(3);
            bt_js_all = (btn_speedupAll)GetChildAt(4);
            com_timeDown = (c_timeDown)GetChildAt(5);
            com_residue = (c_residue)GetChildAt(6);
            btn_video = (btn_video)GetChildAt(7);
            free_speed = (btn_free_speed)GetChildAt(8);
        }
    }
}