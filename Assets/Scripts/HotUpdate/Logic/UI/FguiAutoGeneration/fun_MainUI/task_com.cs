/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class task_com : GComponent
    {
        public GImage n16;
        public GLoader pic;
        public GLoader3D spine1;
        public GTextField decLab;
        public GTextField proLab;
        public GTextField numLab;
        public GLoader3D spine2;
        public GGraph rect;
        public const string URL = "ui://fa0hi8ybv5lj4l";

        public static task_com CreateInstance()
        {
            return (task_com)UIPackage.CreateObject("fun_MainUI", "task_com");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n16 = (GImage)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            spine1 = (GLoader3D)GetChildAt(2);
            decLab = (GTextField)GetChildAt(3);
            proLab = (GTextField)GetChildAt(4);
            numLab = (GTextField)GetChildAt(5);
            spine2 = (GLoader3D)GetChildAt(6);
            rect = (GGraph)GetChildAt(7);
        }
    }
}