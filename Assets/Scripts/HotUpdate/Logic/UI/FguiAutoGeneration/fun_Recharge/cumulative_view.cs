/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class cumulative_view : GComponent
    {
        public Controller type;
        public Controller status;
        public GLoader bg;
        public GList page_list;
        public GLoader3D spine;
        public GLoader name_bg;
        public GLoader rare_img;
        public GImage n48;
        public GImage n49;
        public GTextField nameLab;
        public GTextField decLab;
        public GGroup n51;
        public GImage n52;
        public GImage n53;
        public GImage n54;
        public GImage n55;
        public GImage getted;
        public GList list;
        public pro pro;
        public GButton goto_btn;
        public GButton get_btn;
        public GTextField proLab;
        public GTextField numLab;
        public GTextField rewardLab;
        public GGroup n57;
        public GImage n44;
        public GImage n45;
        public GTextField tipLab;
        public GGroup n58;
        public GLoader icon;
        public GButton left_btn;
        public GButton right_btn;
        public GGroup n59;
        public const string URL = "ui://w3ox9yltdidl23";

        public static cumulative_view CreateInstance()
        {
            return (cumulative_view)UIPackage.CreateObject("fun_Recharge", "cumulative_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            status = GetControllerAt(1);
            bg = (GLoader)GetChildAt(0);
            page_list = (GList)GetChildAt(1);
            spine = (GLoader3D)GetChildAt(2);
            name_bg = (GLoader)GetChildAt(3);
            rare_img = (GLoader)GetChildAt(4);
            n48 = (GImage)GetChildAt(5);
            n49 = (GImage)GetChildAt(6);
            nameLab = (GTextField)GetChildAt(7);
            decLab = (GTextField)GetChildAt(8);
            n51 = (GGroup)GetChildAt(9);
            n52 = (GImage)GetChildAt(10);
            n53 = (GImage)GetChildAt(11);
            n54 = (GImage)GetChildAt(12);
            n55 = (GImage)GetChildAt(13);
            getted = (GImage)GetChildAt(14);
            list = (GList)GetChildAt(15);
            pro = (pro)GetChildAt(16);
            goto_btn = (GButton)GetChildAt(17);
            get_btn = (GButton)GetChildAt(18);
            proLab = (GTextField)GetChildAt(19);
            numLab = (GTextField)GetChildAt(20);
            rewardLab = (GTextField)GetChildAt(21);
            n57 = (GGroup)GetChildAt(22);
            n44 = (GImage)GetChildAt(23);
            n45 = (GImage)GetChildAt(24);
            tipLab = (GTextField)GetChildAt(25);
            n58 = (GGroup)GetChildAt(26);
            icon = (GLoader)GetChildAt(27);
            left_btn = (GButton)GetChildAt(28);
            right_btn = (GButton)GetChildAt(29);
            n59 = (GGroup)GetChildAt(30);
        }
    }
}