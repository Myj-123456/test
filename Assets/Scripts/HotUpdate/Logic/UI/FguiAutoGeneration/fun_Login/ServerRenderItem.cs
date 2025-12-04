/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Login
{
    public partial class ServerRenderItem : GButton
    {
        public Controller button;
        public GGraph n3;
        public GTextField txt_serverName;
        public GTextField txt_host;
        public const string URL = "ui://sid64f75t7qpg";

        public static ServerRenderItem CreateInstance()
        {
            return (ServerRenderItem)UIPackage.CreateObject("fun_Login", "ServerRenderItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n3 = (GGraph)GetChildAt(0);
            txt_serverName = (GTextField)GetChildAt(1);
            txt_host = (GTextField)GetChildAt(2);
        }
    }
}