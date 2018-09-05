using System.Windows.Media;

namespace Sting.Immutable
{
    public readonly struct Color32
    {
        public readonly byte A;
        public readonly byte R;
        public readonly byte G;
        public readonly byte B;

        public Color32(byte a, byte r, byte g, byte b) => (A, R, G, B) = (a, r, g, b);

        public static implicit operator Color32(Color source) => new Color32(source.A, source.R, source.G, source.B);

        public static implicit operator Color(Color32 source) => Color.FromArgb(source.A, source.R, source.G, source.B);

        public static Color32 FromInt(int color)
        {
            return new Color32((byte)(color >> 24), (byte)(color >> 16), (byte)(color >> 8), (byte)color);
        }

        public static int ToInt(Color32 color)
        {
            return color.A << 24 + color.R << +16 + color.G << 8 + color.B;
        }
    }
}