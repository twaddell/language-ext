namespace LanguageExt
{
    public static class Epimorphism
    {
        /// <summary>
        /// Identity epimorphism
        /// </summary>
        public static Epimorphism<A, A> identity<A>() =>
            Epimorphism<A, A>.New(
                Get: a => a,
                Set: a => a);

        /// <summary>
        /// Convert an Epimorphism<A,B> to a Prism<A,B>
        /// </summary>
        public static Prism<A, B> ToPrism<A, B>(this Epimorphism<A, B> ea) =>
            Prism<A, B>.New(
                Get: ea.Get,
                Set: b => _ => ea.Set(b));
    }
}
