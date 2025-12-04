/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_pass_set_view : GComponent
    {
        public GImage n8;
        public GTextField titleLab;
        public GTextField handLab;
        public GTextField autoLab;
        public GComponent handBtn;
        public GComponent autoBtn;
        public GButton saveBtn;
        public GButton close_btn;
        public const string URL = "ui://6wv667guo7qr1ayr88m";

        public static guild_pass_set_view CreateInstance()
        {
            return (guild_pass_set_view)UIPackage.CreateObject("fun_Guild", "guild_pass_set_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n8 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            handLab = (GTextField)GetChildAt(2);
            autoLab = (GTextField)GetChildAt(3);
            handBtn = (GComponent)GetChildAt(4);
            autoBtn = (GComponent)GetChildAt(5);
            saveBtn = (GButton)GetChildAt(6);
            close_btn = (GButton)GetChildAt(7);
        }
    }
}