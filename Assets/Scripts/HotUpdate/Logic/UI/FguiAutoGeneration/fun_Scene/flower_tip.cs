/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class flower_tip : GComponent
    {
        public GImage n0;
        public GLoader pic;
        public GTextField tip_lab;
        public Transition t0;
        public const string URL = "ui://dpcxz2fi9sto3c";

        public static flower_tip CreateInstance()
        {
            return (flower_tip)UIPackage.CreateObject("fun_Scene", "flower_tip");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            tip_lab = (GTextField)GetChildAt(2);
            t0 = GetTransitionAt(0);
        }
    }
}