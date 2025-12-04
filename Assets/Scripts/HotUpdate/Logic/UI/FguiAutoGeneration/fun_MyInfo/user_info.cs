/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class user_info : GComponent
    {
        public GImage n52;
        public GImage n53;
        public GLoader bg;
        public GImage n55;
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
        public privacyBtn privacyBtn;
        public GTextField txt_gameVer;
        public const string URL = "ui://ehkqmfbps23e1yjp7t3";

        public static user_info CreateInstance()
        {
            return (user_info)UIPackage.CreateObject("fun_MyInfo", "user_info");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n52 = (GImage)GetChildAt(0);
            n53 = (GImage)GetChildAt(1);
            bg = (GLoader)GetChildAt(2);
            n55 = (GImage)GetChildAt(3);
            close_btn = (GButton)GetChildAt(4);
            txt_onekey = (GTextField)GetChildAt(5);
            toggle_harvest = (ToggleButton)GetChildAt(6);
            txt_sound = (GTextField)GetChildAt(7);
            txt_bgm = (GTextField)GetChildAt(8);
            toggle_2 = (ToggleButton)GetChildAt(9);
            toggle_1 = (ToggleButton)GetChildAt(10);
            txt_anim = (GTextField)GetChildAt(11);
            toggle_anim = (ToggleButton)GetChildAt(12);
            tip = (GTextField)GetChildAt(13);
            agreeBtn = (greeBtn)GetChildAt(14);
            privacyBtn = (privacyBtn)GetChildAt(15);
            txt_gameVer = (GTextField)GetChildAt(16);
        }
    }
}