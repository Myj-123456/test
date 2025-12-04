/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class DropCom : GComponent
    {
        public ImgCom ImgCom;
        public TextCom TextCom;
        public const string URL = "ui://mjiw43v9q9bj1yjp7u5";

        public static DropCom CreateInstance()
        {
            return (DropCom)UIPackage.CreateObject("common_New", "DropCom");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            ImgCom = (ImgCom)GetChildAt(0);
            TextCom = (TextCom)GetChildAt(1);
        }
    }
}