using System;

namespace LanguageExt
{
    /// <summary>
    /// Primitive epimorphism type for creating bidirectional conversions
    /// </summary>
    public readonly struct Epimorphism<A, B>
    {
        public readonly Func<A, Option<B>> Get;
        public readonly Func<B, A> Set;

        Epimorphism(Func<A, Option<B>> get, Func<B, A> set)
        {
            Get = get;
            Set = set;
        }

        public Func<A, A> Update(Func<B, B> f)
        {
            var self = this;
            return a => self.Get(a)
                            .Map(v => self.Set(f(v)))
                            .IfNone(a);
        }

        public A Update(Func<B, B> f, A value)
        {
            var self = this;
            return Get(value)
                   .Map(v => self.Set(f(v)))
                   .IfNone(value);
        }

        public static Epimorphism<A, B> New(Func<A, Option<B>> Get, Func<B, A> Set) =>
            new Epimorphism<A, B>(Get, Set);
    }
}
