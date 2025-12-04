/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Draw
{
    public partial class skip_btn : GComponent
    {
        public Controller status;
        public GImage n1;
        public GImage n2;
        public const string URL = "ui://97nah3kh11rnuh";

        public static skip_btn CreateInstance()
        {
            return (skip_btn)UIPackage.CreateObject("fun_Draw", "skip_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
        }
    }
}