/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Decrypt
{
    public partial class decrypt_altar_view : GComponent
    {
        public GLoader bg;
        public GLoader item1;
        public GLoader item2;
        public GLoader item3;
        public GLoader drag1;
        public GLoader drag2;
        public GLoader drag3;
        public const string URL = "ui://vlp4zk70xc4q0";

        public static decrypt_altar_view CreateInstance()
        {
            return (decrypt_altar_view)UIPackage.CreateObject("fun_Decrypt", "decrypt_altar_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            item1 = (GLoader)GetChildAt(1);
            item2 = (GLoader)GetChildAt(2);
            item3 = (GLoader)GetChildAt(3);
            drag1 = (GLoader)GetChildAt(4);
            drag2 = (GLoader)GetChildAt(5);
            drag3 = (GLoader)GetChildAt(6);
        }
    }
}