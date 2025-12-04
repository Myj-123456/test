/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class frame_view : GComponent
    {
        public Controller unlock;
        public GLoader head_img;
        public GComponent ftame;
        public GTextField tipLab;
        public GButton wear_btn;
        public GButton goto_btn;
        public GList list;
        public const string URL = "ui://ehkqmfbpj9p61yjp7yu";

        public static frame_view CreateInstance()
        {
            return (frame_view)UIPackage.CreateObject("fun_MyInfo", "frame_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            unlock = GetControllerAt(0);
            head_img = (GLoader)GetChildAt(0);
            ftame = (GComponent)GetChildAt(1);
            tipLab = (GTextField)GetChildAt(2);
            wear_btn = (GButton)GetChildAt(3);
            goto_btn = (GButton)GetChildAt(4);
            list = (GList)GetChildAt(5);
        }
    }
}