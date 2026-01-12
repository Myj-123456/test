/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class playerItemRenderer : GComponent
    {
        public Controller bg;
        public Controller sex;
        public Controller playerStatus;
        public GImage n35;
        public GTextField txt_userName;
        public GTextField txt_status;
        public GTextField txt_date;
        public GTextField txt_master;
        public GButton btn_rob;
        public GLoader pic;
        public GTextField txt_title;
        public robbedHead_big master_head;
        public const string URL = "ui://z1on8kwdku0fpjn";

        public static playerItemRenderer CreateInstance()
        {
            return (playerItemRenderer)UIPackage.CreateObject("fun_Rob", "playerItemRenderer");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = GetControllerAt(0);
            sex = GetControllerAt(1);
            playerStatus = GetControllerAt(2);
            n35 = (GImage)GetChildAt(0);
            txt_userName = (GTextField)GetChildAt(1);
            txt_status = (GTextField)GetChildAt(2);
            txt_date = (GTextField)GetChildAt(3);
            txt_master = (GTextField)GetChildAt(4);
            btn_rob = (GButton)GetChildAt(5);
            pic = (GLoader)GetChildAt(6);
            txt_title = (GTextField)GetChildAt(7);
            master_head = (robbedHead_big)GetChildAt(8);
        }
    }
}