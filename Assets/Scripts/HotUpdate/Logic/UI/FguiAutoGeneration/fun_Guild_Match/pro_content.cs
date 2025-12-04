/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_Match
{
    public partial class pro_content : GComponent
    {
        public pro pro;
        public const string URL = "ui://qefze8qitewh4";

        public static pro_content CreateInstance()
        {
            return (pro_content)UIPackage.CreateObject("fun_Guild_Match", "pro_content");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            pro = (pro)GetChildAt(0);
        }
    }
}