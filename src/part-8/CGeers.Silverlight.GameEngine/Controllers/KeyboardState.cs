using System.Windows;
using System.Windows.Input;

namespace CGeers.Silverlight.GameEngine.Controllers
{
    public static class KeyboardState
    {
        private const int MAX_KEYS = 256;
        private static bool[] _states = new bool[MAX_KEYS];

        public static bool GetKeyState(Key key)
        {
            int index = (int) key;
            if (index < 0 || index >= MAX_KEYS)
            {
                return false;
            }
            return _states[index];
        }

        public static void SetKeyState(Key key)
        {
            int index = (int) key;
            if (index < 0 || index >= MAX_KEYS)
            {
                return;
            }
            _states[index] = true;
        }

        public static void HookEvents(UIElement uiElement)
        {
            if (uiElement != null)
            {
                uiElement.KeyDown += OnKeyDown;
                uiElement.KeyUp += OnKeyUp;
            }
        }

        public static void UnhookEvents(UIElement uiElement)
        {
            if (uiElement != null)
            {
                uiElement.KeyDown -= OnKeyDown;
                uiElement.KeyUp -= OnKeyUp;
            }
        }

        private static void OnKeyUp(object sender, KeyEventArgs e)
        {
            _states[(int) e.Key] = false;
        }

        private static void OnKeyDown(object sender, KeyEventArgs e)
        {
            _states[(int) e.Key] = true;
        }
    }
}
