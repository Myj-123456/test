/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class robbedSpeed : GProgressBar
    {
        public GImage n0;
        public GImage bar;
        public const string URL = "ui://z1on8kwdiy851ayr8ml";

        public static robbedSpeed CreateInstance()
        {
            return (robbedSpeed)UIPackage.CreateObject("fun_Rob", "robbedSpeed");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            bar = (GImage)GetChildAt(1);
        }
    }
}