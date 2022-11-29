using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageExt
{
    public static class OpticsComposer
    {
        /// <summary>
        /// Sequentially composes two lenses
        /// </summary>
        public static Lens<A, C> Compose<A, B, C>(this Lens<A, B> la, Lens<B, C> lb) =>
            Prelude.lens(la, lb);

        /// <summary>
        /// Sequentially composes a lens and a prism
        /// </summary>
        public static Prism<A, C> Compose<A, B, C>(this Lens<A, B> la, Prism<B, C> pb) =>
            Prelude.prism(la, pb);

        /// <summary>
        /// Sequentially composes two prisms
        /// </summary>
        public static Prism<A, C> Compose<A, B, C>(this Prism<A, B> pa, Prism<B, C> pb) =>
            Prelude.prism(pa, pb);

        /// <summary>
        /// Sequentially composes a prism and a lens
        /// </summary>
        public static Prism<A, C> Compose<A, B, C>(this Prism<A, B> pa, Lens<B, C> lb) =>
            Prelude.prism(pa, lb);

        /// <summary>
        /// Sequentially composes a lens and an isomorphism
        /// </summary>
        public static Lens<A, C> Compose<A, B, C>(this Lens<A, B> la, Isomorphism<B, C> ib) =>
            Prelude.lens(la, ib);

        /// <summary>
        /// Sequentially composes an isomorphism and a lens
        /// </summary>
        public static Lens<A, C> Compose<A, B, C>(this Isomorphism<A, B> ia, Lens<B, C> lb) =>
            Prelude.lens(ia, lb);

        /// <summary>
        /// Sequentially composes a prism and an isomorphism
        /// </summary>
        public static Prism<A, C> Compose<A, B, C>(this Prism<A, B> pa, Isomorphism<B, C> ib) =>
            Prelude.prism(pa, ib);

        /// <summary>
        /// Sequentially composes an isomorphism and a prism
        /// </summary>
        public static Prism<A, C> Compose<A, B, C>(this Isomorphism<A, B> ia, Prism<B, C> pb) =>
            Prelude.prism(ia, pb);

        /// <summary>
        /// Sequentially composes a lens and an epimorphism
        /// </summary>
        public static Prism<A, C> Compose<A, B, C>(this Lens<A, B> la, Epimorphism<B, C> eb) =>
            Prelude.prism(la, eb);

        /// <summary>
        /// Sequentially composes an epimorphism and a lens
        /// </summary>
        public static Prism<A, C> Compose<A, B, C>(this Epimorphism<A, B> ea, Lens<B, C> lb) =>
            Prelude.prism(ea, lb);

        /// <summary>
        /// Sequentially composes a prism and an epimorphism
        /// </summary>
        public static Prism<A, C> Compose<A, B, C>(this Prism<A, B> pa, Epimorphism<B, C> eb) =>
            Prelude.prism(pa, eb);

        /// <summary>
        /// Sequentially composes an epimorphism and a prism
        /// </summary>
        public static Prism<A, C> Compose<A, B, C>(this Epimorphism<A, B> ea, Prism<B, C> pb) =>
            Prelude.prism(ea, pb);
    }
}
