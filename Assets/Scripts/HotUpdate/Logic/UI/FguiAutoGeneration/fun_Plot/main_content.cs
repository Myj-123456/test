/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Plot
{
    public partial class main_content : GComponent
    {
        public GLoader bg;
        public GList list;
        public GGraph n4;
        public Transition play_show;
        public const string URL = "ui://vucpfjl8accs1yjp837";

        public static main_content CreateInstance()
        {
            return (main_content)UIPackage.CreateObject("fun_Plot", "main_content");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            list = (GList)GetChildAt(1);
            n4 = (GGraph)GetChildAt(2);
            play_show = GetTransitionAt(0);
        }
    }
}