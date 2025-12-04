/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Chat
{
    public partial class friend_item : GComponent
    {
        public GImage n1;
        public GImage n10;
        public GImage n4;
        public GTextField txt_lv;
        public GTextField nameLab;
        public GTextField txt_content;
        public GTextField timeLab;
        public GGraph rect;
        public chatHead head;
        public btn3 del_btn;
        public const string URL = "ui://z9jypfq8sh8h1yjp7ws";

        public static friend_item CreateInstance()
        {
            return (friend_item)UIPackage.CreateObject("fun_Chat", "friend_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            n10 = (GImage)GetChildAt(1);
            n4 = (GImage)GetChildAt(2);
            txt_lv = (GTextField)GetChildAt(3);
            nameLab = (GTextField)GetChildAt(4);
            txt_content = (GTextField)GetChildAt(5);
            timeLab = (GTextField)GetChildAt(6);
            rect = (GGraph)GetChildAt(7);
            head = (chatHead)GetChildAt(8);
            del_btn = (btn3)GetChildAt(9);
        }
    }
}