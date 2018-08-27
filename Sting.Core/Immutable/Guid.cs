using System;
using System.Runtime.InteropServices;

namespace Sting.Immutable
{
    [StructLayout(LayoutKind.Explicit)]
    public readonly struct Guid : IEquatable<Guid>
    {
        public static readonly Guid Empty = new Guid();

        [FieldOffset(0)]
        private readonly System.Guid _guid;

        [FieldOffset(0)]
        private readonly ulong _low;

        [FieldOffset(8)]
        private readonly ulong _high;

        [FieldOffset(0)]
        private readonly int _a;

        [FieldOffset(4)]
        private readonly int _bc;

        [FieldOffset(8)]
        private readonly int _defg;

        [FieldOffset(12)]
        private readonly int _hijk;

        public Guid(in System.Guid guid) : this() => _guid = guid;

        public static implicit operator System.Guid(in Guid source) => source._guid;

        public static implicit operator Guid(in System.Guid source) => new Guid(source);

        public static Guid AsRef(in System.Guid guid) => new Guid(guid);

        public new int GetHashCode() => _a ^ _bc ^ _defg ^ _hijk;

        public bool Equals(Guid other) => _low == other._low && _high == other._high;

        public bool Equals(in Guid other) => _low == other._low && _high == other._high;
    }
}