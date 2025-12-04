/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class rob_reward_box : GComponent
    {
        public Controller status;
        public GImage n8;
        public GImage n2;
        public GLoader img_ItemIcon;
        public GRichTextField lb_name0;
        public GRichTextField lb_name1;
        public const string URL = "ui://z1on8kwdku0fpk8";

        public static rob_reward_box CreateInstance()
        {
            return (rob_reward_box)UIPackage.CreateObject("fun_Rob", "rob_reward_box");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n8 = (GImage)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            img_ItemIcon = (GLoader)GetChildAt(2);
            lb_name0 = (GRichTextField)GetChildAt(3);
            lb_name1 = (GRichTextField)GetChildAt(4);
        }
    }
}