/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Notice
{
    public partial class UpdateContent : GComponent
    {
        public GList list;
        public const string URL = "ui://6ijclyxxnhwyvgk2og";

        public static UpdateContent CreateInstance()
        {
            return (UpdateContent)UIPackage.CreateObject("fun_Notice", "UpdateContent");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            list = (GList)GetChildAt(0);
        }
    }
}