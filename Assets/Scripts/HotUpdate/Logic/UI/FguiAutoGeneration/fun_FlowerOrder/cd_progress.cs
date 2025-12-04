/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerOrder
{
    public partial class cd_progress : GProgressBar
    {
        public GImage n5;
        public GImage bar;
        public GImage proImg;
        public const string URL = "ui://6euywhvrr7kk1ayr8as";

        public static cd_progress CreateInstance()
        {
            return (cd_progress)UIPackage.CreateObject("fun_FlowerOrder", "cd_progress");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n5 = (GImage)GetChildAt(0);
            bar = (GImage)GetChildAt(1);
            proImg = (GImage)GetChildAt(2);
        }
    }
}