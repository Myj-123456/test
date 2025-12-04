/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Chat
{
    public partial class chat_main_view : GComponent
    {
        public Controller tab;
        public GLoader bg;
        public world_view world_view;
        public guild_view guild_view;
        public friend_view friend_view;
        public btn close_btn;
        public GImage n10;
        public GRichTextField tipLab;
        public GGroup n14;
        public GImage n13;
        public page_btn world_btn;
        public page_btn guild_btn;
        public page_btn friend_btn;
        public GGroup n15;
        public const string URL = "ui://z9jypfq8didl1yjp7wm";

        public static chat_main_view CreateInstance()
        {
            return (chat_main_view)UIPackage.CreateObject("fun_Chat", "chat_main_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            world_view = (world_view)GetChildAt(1);
            guild_view = (guild_view)GetChildAt(2);
            friend_view = (friend_view)GetChildAt(3);
            close_btn = (btn)GetChildAt(4);
            n10 = (GImage)GetChildAt(5);
            tipLab = (GRichTextField)GetChildAt(6);
            n14 = (GGroup)GetChildAt(7);
            n13 = (GImage)GetChildAt(8);
            world_btn = (page_btn)GetChildAt(9);
            guild_btn = (page_btn)GetChildAt(10);
            friend_btn = (page_btn)GetChildAt(11);
            n15 = (GGroup)GetChildAt(12);
        }
    }
}