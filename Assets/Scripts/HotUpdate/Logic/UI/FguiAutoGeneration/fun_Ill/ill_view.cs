/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Ill
{
    public partial class ill_view : GComponent
    {
        public Controller tab;
        public GGraph n10;
        public GButton flower_btn;
        public GButton vase_btn;
        public GButton dress_btn;
        public GButton florist_btn;
        public GButton pet_btn;
        public GButton fairy_btn;
        public GGroup n8;
        public GButton close_btn;
        public GList list;
        public const string URL = "ui://p737delgcs1m0";

        public static ill_view CreateInstance()
        {
            return (ill_view)UIPackage.CreateObject("fun_Ill", "ill_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            n10 = (GGraph)GetChildAt(0);
            flower_btn = (GButton)GetChildAt(1);
            vase_btn = (GButton)GetChildAt(2);
            dress_btn = (GButton)GetChildAt(3);
            florist_btn = (GButton)GetChildAt(4);
            pet_btn = (GButton)GetChildAt(5);
            fairy_btn = (GButton)GetChildAt(6);
            n8 = (GGroup)GetChildAt(7);
            close_btn = (GButton)GetChildAt(8);
            list = (GList)GetChildAt(9);
        }
    }
}