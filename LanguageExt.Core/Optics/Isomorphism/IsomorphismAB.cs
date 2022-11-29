using System;

namespace LanguageExt
{
    /// <summary>
    /// Primitive isomorphism type for creating bidirectional conversions
    /// </summary>
    public readonly struct Isomorphism<A, B>
    {
        public readonly Func<A, B> Get;
        public readonly Func<B, A> Set;

        Isomorphism(Func<A, B> get, Func<B, A> set)
        {
            Get = get;
            Set = set;
        }

        public Func<A, A> Update(Func<B, B> f)
        {
            var self = this;
            return a => self.Set(f(self.Get(a)));
        }

        public A Update(Func<B, B> f, A value) => 
            Set(f(Get(value)));

        public static Isomorphism<A, B> New(Func<A, B> Get, Func<B, A> Set) =>
            new Isomorphism<A, B>(Get, Set);
    }
}
