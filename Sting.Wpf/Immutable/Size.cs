using System;

namespace Sting.Immutable
{
    public readonly struct Size : IEquatable<Size>
    {
        public readonly double Width;

        public readonly double Height;

        public Size(double width, double height) => (Width, Height) = (width, height);

        public bool Equals(Size other) => Width == other.Width && Height == other.Height;

        public static implicit operator Size(System.Windows.Size source) => new Size(source.Width, source.Height);

        public static implicit operator System.Windows.Size(in Size source) => new System.Windows.Size(source.Width, source.Height);

        public static bool operator ==(in Size source1, in Size source2) => source1.Width == source2.Width && source1.Height == source2.Height;

        public static bool operator !=(in Size source1, in Size source2) => !(source1 == source2);

        public override bool Equals(object obj)
        {
            if (obj is Size other)
            {
                return this == other;
            }
            return false;
        }

        public override int GetHashCode() => Width.GetHashCode() ^ ~Height.GetHashCode();
    }
}