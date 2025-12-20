/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class robbedCell2 : GComponent
    {
        public Controller status;
        public GImage n46;
        public GLoader img_head;
        public robbedSpeed jindu;
        public GLoader img_reward;
        public GImage n48;
        public GImage n53;
        public GImage n54;
        public const string URL = "ui://z1on8kwdiy851ayr8mo";

        public static robbedCell2 CreateInstance()
        {
            return (robbedCell2)UIPackage.CreateObject("fun_Rob", "robbedCell2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n46 = (GImage)GetChildAt(0);
            img_head = (GLoader)GetChildAt(1);
            jindu = (robbedSpeed)GetChildAt(2);
            img_reward = (GLoader)GetChildAt(3);
            n48 = (GImage)GetChildAt(4);
            n53 = (GImage)GetChildAt(5);
            n54 = (GImage)GetChildAt(6);
        }
    }
}