/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Login
{
    public partial class TaptapLoginView : GComponent
    {
        public TabtapLoginButton btn_login;
        public StartGameButton btn_startGame;
        public const string URL = "ui://sid64f75r9d6l";

        public static TaptapLoginView CreateInstance()
        {
            return (TaptapLoginView)UIPackage.CreateObject("fun_Login", "TaptapLoginView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            btn_login = (TabtapLoginButton)GetChildAt(0);
            btn_startGame = (StartGameButton)GetChildAt(1);
        }
    }
}