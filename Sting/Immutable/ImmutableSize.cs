using System;
using System.Windows;

namespace Sting
{
    public readonly struct ImmutableSize : IEquatable<ImmutableSize>
    {
        public readonly double Width;

        public readonly double Height;

        public ImmutableSize(double width, double height) => (Width, Height) = (width, height);

        public bool Equals(ImmutableSize other) => Width == other.Width && Height == other.Height;

        public static implicit operator ImmutableSize(Size source) => new ImmutableSize(source.Width, source.Height);

        public static implicit operator Size(in ImmutableSize source) => new Size(source.Width, source.Height);

        public static bool operator ==(in ImmutableSize source1, in ImmutableSize source2) => source1.Width == source2.Width && source1.Height == source2.Height;

        public static bool operator !=(in ImmutableSize source1, in ImmutableSize source2) => !(source1 == source2);

        public override bool Equals(object obj)
        {
            if (obj is ImmutableSize other)
            {
                return this == other;
            }
            return false;
        }

        public override int GetHashCode() => Width.GetHashCode() ^ ~Height.GetHashCode();
    }
}