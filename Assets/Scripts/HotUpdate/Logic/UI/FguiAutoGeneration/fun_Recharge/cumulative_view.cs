/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class cumulative_view : GComponent
    {
        public Controller type;
        public GLoader bg;
        public GLoader bg2;
        public GLoader bg1;
        public GList page_list;
        public GImage n11;
        public GImage n13;
        public GTextField tipLab;
        public GGroup n37;
        public GImage n25;
        public GLoader icon;
        public GLoader3D spine;
        public btn left_btn;
        public btn right_btn;
        public GGroup n40;
        public GLoader name_bg;
        public GLoader rare_img;
        public GTextField nameLab;
        public GGroup n33;
        public GImage n16;
        public GImage n15;
        public GImage n17;
        public GImage n19;
        public GImage n21;
        public GImage n23;
        public GImage n24;
        public GList list;
        public pro pro;
        public GButton goto_btn;
        public GButton get_btn;
        public GTextField proLab;
        public GTextField decLab;
        public GTextField numLab;
        public GTextField rewardLab;
        public GGroup n39;
        public const string URL = "ui://w3ox9yltdidl23";

        public static cumulative_view CreateInstance()
        {
            return (cumulative_view)UIPackage.CreateObject("fun_Recharge", "cumulative_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            bg2 = (GLoader)GetChildAt(1);
            bg1 = (GLoader)GetChildAt(2);
            page_list = (GList)GetChildAt(3);
            n11 = (GImage)GetChildAt(4);
            n13 = (GImage)GetChildAt(5);
            tipLab = (GTextField)GetChildAt(6);
            n37 = (GGroup)GetChildAt(7);
            n25 = (GImage)GetChildAt(8);
            icon = (GLoader)GetChildAt(9);
            spine = (GLoader3D)GetChildAt(10);
            left_btn = (btn)GetChildAt(11);
            right_btn = (btn)GetChildAt(12);
            n40 = (GGroup)GetChildAt(13);
            name_bg = (GLoader)GetChildAt(14);
            rare_img = (GLoader)GetChildAt(15);
            nameLab = (GTextField)GetChildAt(16);
            n33 = (GGroup)GetChildAt(17);
            n16 = (GImage)GetChildAt(18);
            n15 = (GImage)GetChildAt(19);
            n17 = (GImage)GetChildAt(20);
            n19 = (GImage)GetChildAt(21);
            n21 = (GImage)GetChildAt(22);
            n23 = (GImage)GetChildAt(23);
            n24 = (GImage)GetChildAt(24);
            list = (GList)GetChildAt(25);
            pro = (pro)GetChildAt(26);
            goto_btn = (GButton)GetChildAt(27);
            get_btn = (GButton)GetChildAt(28);
            proLab = (GTextField)GetChildAt(29);
            decLab = (GTextField)GetChildAt(30);
            numLab = (GTextField)GetChildAt(31);
            rewardLab = (GTextField)GetChildAt(32);
            n39 = (GGroup)GetChildAt(33);
        }
    }
}