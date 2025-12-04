/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Customer
{
    public partial class like_item : GComponent
    {
        public Controller status;
        public Controller pos;
        public Controller end;
        public GImage n8;
        public GImage n1;
        public GImage n10;
        public GImage n7;
        public GImage n16;
        public GImage n17;
        public GGroup n18;
        public GImage n19;
        public GImage n20;
        public GGroup n21;
        public GGroup n22;
        public GTextField nameLab;
        public GTextField gotoLab;
        public GTextField lockLab;
        public GList reward_list;
        public GLoader goto_btn;
        public GImage n12;
        public GImage n13;
        public GTextField lvLab;
        public GGroup n15;
        public const string URL = "ui://pcr735xhcs1m1e";

        public static like_item CreateInstance()
        {
            return (like_item)UIPackage.CreateObject("fun_Customer", "like_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            pos = GetControllerAt(1);
            end = GetControllerAt(2);
            n8 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            n10 = (GImage)GetChildAt(2);
            n7 = (GImage)GetChildAt(3);
            n16 = (GImage)GetChildAt(4);
            n17 = (GImage)GetChildAt(5);
            n18 = (GGroup)GetChildAt(6);
            n19 = (GImage)GetChildAt(7);
            n20 = (GImage)GetChildAt(8);
            n21 = (GGroup)GetChildAt(9);
            n22 = (GGroup)GetChildAt(10);
            nameLab = (GTextField)GetChildAt(11);
            gotoLab = (GTextField)GetChildAt(12);
            lockLab = (GTextField)GetChildAt(13);
            reward_list = (GList)GetChildAt(14);
            goto_btn = (GLoader)GetChildAt(15);
            n12 = (GImage)GetChildAt(16);
            n13 = (GImage)GetChildAt(17);
            lvLab = (GTextField)GetChildAt(18);
            n15 = (GGroup)GetChildAt(19);
        }
    }
}