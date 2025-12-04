/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class title_view : GComponent
    {
        public Controller status;
        public GLoader icon;
        public GTextField nameLab;
        public GTextField tipLab;
        public GButton remove_btn;
        public GButton wear_btn;
        public GButton goto_btn;
        public GList list;
        public const string URL = "ui://ehkqmfbpj9p61yjp7yh";

        public static title_view CreateInstance()
        {
            return (title_view)UIPackage.CreateObject("fun_MyInfo", "title_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            icon = (GLoader)GetChildAt(0);
            nameLab = (GTextField)GetChildAt(1);
            tipLab = (GTextField)GetChildAt(2);
            remove_btn = (GButton)GetChildAt(3);
            wear_btn = (GButton)GetChildAt(4);
            goto_btn = (GButton)GetChildAt(5);
            list = (GList)GetChildAt(6);
        }
    }
}