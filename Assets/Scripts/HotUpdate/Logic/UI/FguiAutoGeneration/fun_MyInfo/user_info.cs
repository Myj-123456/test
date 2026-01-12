/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class user_info : GComponent
    {
        public Controller status;
        public GLoader bg;
        public GImage n58;
        public GTextField titleLab;
        public GButton close_btn;
        public GTextField txt_onekey;
        public ToggleButton toggle_harvest;
        public GTextField txt_sound;
        public GTextField txt_bgm;
        public ToggleButton toggle_2;
        public ToggleButton toggle_1;
        public GTextField txt_anim;
        public ToggleButton toggle_anim;
        public GTextField tip;
        public greeBtn agreeBtn;
        public greeBtn privacyBtn;
        public greeBtn destroyBtn;
        public GTextField txt_gameVer;
        public const string URL = "ui://ehkqmfbps23e1yjp7t3";

        public static user_info CreateInstance()
        {
            return (user_info)UIPackage.CreateObject("fun_MyInfo", "user_info");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            n58 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            close_btn = (GButton)GetChildAt(3);
            txt_onekey = (GTextField)GetChildAt(4);
            toggle_harvest = (ToggleButton)GetChildAt(5);
            txt_sound = (GTextField)GetChildAt(6);
            txt_bgm = (GTextField)GetChildAt(7);
            toggle_2 = (ToggleButton)GetChildAt(8);
            toggle_1 = (ToggleButton)GetChildAt(9);
            txt_anim = (GTextField)GetChildAt(10);
            toggle_anim = (ToggleButton)GetChildAt(11);
            tip = (GTextField)GetChildAt(12);
            agreeBtn = (greeBtn)GetChildAt(13);
            privacyBtn = (greeBtn)GetChildAt(14);
            destroyBtn = (greeBtn)GetChildAt(15);
            txt_gameVer = (GTextField)GetChildAt(16);
        }
    }
}