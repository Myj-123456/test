/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_Match
{
    public partial class head : GComponent
    {
        public GLoader pic;
        public GComponent frame;
        public const string URL = "ui://qefze8qir0nz1w";

        public static head CreateInstance()
        {
            return (head)UIPackage.CreateObject("fun_Guild_Match", "head");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            pic = (GLoader)GetChildAt(0);
            frame = (GComponent)GetChildAt(1);
        }
    }
}