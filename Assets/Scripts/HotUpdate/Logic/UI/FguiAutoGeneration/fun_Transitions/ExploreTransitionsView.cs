/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Transitions
{
    public partial class ExploreTransitionsView : GComponent
    {
        public GImage n0;
        public GTextField txt_progress;
        public GTextField txt_des;
        public GGroup gloup;
        public GLoader3D loader_spine;
        public const string URL = "ui://02794pgwluhj4";

        public static ExploreTransitionsView CreateInstance()
        {
            return (ExploreTransitionsView)UIPackage.CreateObject("fun_Transitions", "ExploreTransitionsView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            txt_progress = (GTextField)GetChildAt(1);
            txt_des = (GTextField)GetChildAt(2);
            gloup = (GGroup)GetChildAt(3);
            loader_spine = (GLoader3D)GetChildAt(4);
        }
    }
}