namespace LanguageExt
{
    public static class Isomorphism
    {
        /// <summary>
        /// Identity isomorphism
        /// </summary>
        public static Isomorphism<A, A> identity<A>() =>
            Isomorphism<A, A>.New(
                Get: a => a,
                Set: a => a);

        /// <summary>
        /// Convert an Isomorphism<A,B> to a Prism<A,B>
        /// </summary>
        public static Lens<A, B> ToLens<A, B>(this Isomorphism<A, B> ia) =>
            Lens<A, B>.New(
                Get: ia.Get,
                Set: b => _ => ia.Set(b));
    }
}
