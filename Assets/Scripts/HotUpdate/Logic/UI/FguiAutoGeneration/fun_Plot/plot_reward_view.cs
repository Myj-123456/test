/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Plot
{
    public partial class plot_reward_view : GComponent
    {
        public GImage n2;
        public GLoader bg;
        public GImage n3;
        public GButton close_btn;
        public GButton sure_btn;
        public GList list;
        public const string URL = "ui://vucpfjl811rnu1yjp83i";

        public static plot_reward_view CreateInstance()
        {
            return (plot_reward_view)UIPackage.CreateObject("fun_Plot", "plot_reward_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            close_btn = (GButton)GetChildAt(3);
            sure_btn = (GButton)GetChildAt(4);
            list = (GList)GetChildAt(5);
        }
    }
}