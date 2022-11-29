using System;
using System.Net;
using static LanguageExt.Prelude;

namespace LanguageExt
{
    public static partial class Optics
    {
        public static readonly Epimorphism<string, long> stringLong = StringEpimorphism(parseLong);

        public static readonly Epimorphism<string, int> stringInt = StringEpimorphism(parseInt);

        public static readonly Epimorphism<string, short> stringShort = StringEpimorphism(parseShort);

        public static readonly Epimorphism<string, char> stringChar = StringEpimorphism(parseChar);

        public static readonly Epimorphism<string, sbyte> stringSByte = StringEpimorphism(parseSByte);

        public static readonly Epimorphism<string, byte> stringByte = StringEpimorphism(parseByte);

        public static readonly Epimorphism<string, ulong> stringULong = StringEpimorphism(parseULong);
        
        public static readonly Epimorphism<string, uint> stringUInt = StringEpimorphism(parseUInt);

        public static readonly Epimorphism<string, ushort> stringUShort = StringEpimorphism(parseUShort);
        
        public static readonly Epimorphism<string, float> stringFloat = StringEpimorphism(parseFloat);

        public static readonly Epimorphism<string, double> stringDouble = StringEpimorphism(parseDouble);

        public static readonly Epimorphism<string, decimal> stringDecimal = StringEpimorphism(parseDecimal);

        public static readonly Epimorphism<string, bool> stringBool = StringEpimorphism(parseBool);
        
        public static readonly Epimorphism<string, Guid> stringGuid = StringEpimorphism(parseGuid);

        public static readonly Epimorphism<string, DateTime> stringDateTime = StringEpimorphism(parseDateTime);

        public static readonly Epimorphism<string, DateTimeOffset> stringDateTimeOffset = StringEpimorphism(parseDateTimeOffset);

        public static readonly Epimorphism<string, TimeSpan> stringTimeSpan = StringEpimorphism(parseTimeSpan);

        public static readonly Epimorphism<string, IPAddress> stringIPAddress = StringEpimorphism(parseIPAddress);
        
        private static Epimorphism<string, A> StringEpimorphism<A>(Func<string, LanguageExt.Option<A>> f) =>
            Epimorphism<string, A>.New(
                Get: f,
                Set: value => value.ToString()
            );
    }
}
