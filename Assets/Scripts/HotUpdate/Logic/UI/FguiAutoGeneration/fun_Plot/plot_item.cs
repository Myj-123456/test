/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Plot
{
    public partial class plot_item : GComponent
    {
        public Controller status;
        public Controller type;
        public plot_content content;
        public GList list;
        public GImage n20;
        public GTextField titleLab;
        public GGraph show_btn;
        public GGraph anim;
        public Transition show;
        public Transition hide;
        public const string URL = "ui://vucpfjl8accsw";

        public static plot_item CreateInstance()
        {
            return (plot_item)UIPackage.CreateObject("fun_Plot", "plot_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            type = GetControllerAt(1);
            content = (plot_content)GetChildAt(0);
            list = (GList)GetChildAt(1);
            n20 = (GImage)GetChildAt(2);
            titleLab = (GTextField)GetChildAt(3);
            show_btn = (GGraph)GetChildAt(4);
            anim = (GGraph)GetChildAt(5);
            show = GetTransitionAt(0);
            hide = GetTransitionAt(1);
        }
    }
}