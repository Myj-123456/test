/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerOrder
{
    public partial class orderNpc : GComponent
    {
        public Controller npc;
        public Controller npcOrderStatus;
        public Controller dress;
        public Controller type;
        public GLoader image_loader;
        public GImage n96;
        public GImage n99;
        public GGroup n100;
        public GImage n95;
        public GImage n98;
        public GGroup n105;
        public GImage n106;
        public GGroup n107;
        public GImage n111;
        public GImage n114;
        public GGroup n113;
        public GImage n110;
        public GImage n108;
        public GGraph n102;
        public GTextField timeLab;
        public const string URL = "ui://6euywhvrree11ayr876";

        public static orderNpc CreateInstance()
        {
            return (orderNpc)UIPackage.CreateObject("fun_FlowerOrder", "orderNpc");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            npc = GetControllerAt(0);
            npcOrderStatus = GetControllerAt(1);
            dress = GetControllerAt(2);
            type = GetControllerAt(3);
            image_loader = (GLoader)GetChildAt(0);
            n96 = (GImage)GetChildAt(1);
            n99 = (GImage)GetChildAt(2);
            n100 = (GGroup)GetChildAt(3);
            n95 = (GImage)GetChildAt(4);
            n98 = (GImage)GetChildAt(5);
            n105 = (GGroup)GetChildAt(6);
            n106 = (GImage)GetChildAt(7);
            n107 = (GGroup)GetChildAt(8);
            n111 = (GImage)GetChildAt(9);
            n114 = (GImage)GetChildAt(10);
            n113 = (GGroup)GetChildAt(11);
            n110 = (GImage)GetChildAt(12);
            n108 = (GImage)GetChildAt(13);
            n102 = (GGraph)GetChildAt(14);
            timeLab = (GTextField)GetChildAt(15);
        }
    }
}