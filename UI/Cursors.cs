using System.IO;
using System.Windows;
using System.Windows.Input;

namespace UI
{
    public static class Cursors
    {
        public static Cursor WhiteCursor { get; } = LoadCursor("assets/white/cursor.cur");
        public static Cursor BlackCursor { get; } = LoadCursor("assets/black/cursor.cur");

        private static Cursor LoadCursor(string filepath)
        {
            Stream stream = Application.GetResourceStream(new Uri(filepath, UriKind.Relative)).Stream;
            return new Cursor(stream, true);
        }
    }
}
