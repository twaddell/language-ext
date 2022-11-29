using System.Linq;

namespace LanguageExt
{
    public static partial class Optics
    {
        public static class Seq<A>
        {
            public static readonly Isomorphism<LanguageExt.Seq<A>, A[]> array =
                Isomorphism<LanguageExt.Seq<A>, A[]>.New(
                    Get: s => s.ToArray(),
                    Set: a => a.ToSeq()
                );

            public static readonly Isomorphism<LanguageExt.Seq<A>, LanguageExt.Arr<A>> arr =
                Isomorphism<LanguageExt.Seq<A>, LanguageExt.Arr<A>>.New(
                    Get: s => s.ToArr(),
                    Set: a => a.ToSeq()
                );

            public static readonly Isomorphism<LanguageExt.Seq<A>, LanguageExt.Lst<A>> lst =
                Isomorphism<LanguageExt.Seq<A>, LanguageExt.Lst<A>>.New(
                    Get: s => s.Freeze(),
                    Set: l => l.ToSeq()
                );

            public static readonly Isomorphism<LanguageExt.Seq<A>, LanguageExt.Set<A>> set =
                Isomorphism<LanguageExt.Seq<A>, LanguageExt.Set<A>>.New(
                    Get: s => new LanguageExt.Set<A>(s),
                    Set: s => s.ToSeq()
                );

            public static readonly Isomorphism<LanguageExt.Seq<A>, LanguageExt.HashSet<A>> hashSet =
                Isomorphism<LanguageExt.Seq<A>, LanguageExt.HashSet<A>>.New(
                    Get: s => new LanguageExt.HashSet<A>(s),
                    Set: h => h.ToSeq()
                );
        }

        public static class Lst<A>
        {
            public static readonly Isomorphism<LanguageExt.Lst<A>, A[]> array =
                Isomorphism<LanguageExt.Lst<A>, A[]>.New(
                    Get: a => a.AsEnumerable().ToArray(),
                    Set: s => s.Freeze()
                );

            public static readonly Isomorphism<LanguageExt.Lst<A>, LanguageExt.Arr<A>> arr =
                Isomorphism<LanguageExt.Lst<A>, LanguageExt.Arr<A>>.New(
                    Get: s => s.ToArr(),
                    Set: a => a.Freeze()
                );

            public static readonly Isomorphism<LanguageExt.Lst<A>, LanguageExt.Seq<A>> seq =
                Isomorphism<LanguageExt.Lst<A>, LanguageExt.Seq<A>>.New(
                    Get: l => l.ToSeq(),
                    Set: s => s.Freeze()
                );

            public static readonly Isomorphism<LanguageExt.Lst<A>, LanguageExt.Set<A>> set =
                Isomorphism<LanguageExt.Lst<A>, LanguageExt.Set<A>>.New(
                    Get: l => new LanguageExt.Set<A>(l),
                    Set: s => s.Freeze()
                );

            public static readonly Isomorphism<LanguageExt.Lst<A>, LanguageExt.HashSet<A>> hashSet =
                Isomorphism<LanguageExt.Lst<A>, LanguageExt.HashSet<A>>.New(
                    Get: l => new LanguageExt.HashSet<A>(l),
                    Set: h => h.Freeze()
                );
        }

        public static class Arr<A>
        {
            public static readonly Isomorphism<LanguageExt.Arr<A>, A[]> array =
                Isomorphism<LanguageExt.Arr<A>, A[]>.New(
                    Get: a => a.ToArray(),
                    Set: a => a.ToArr()
                );

            public static readonly Isomorphism<LanguageExt.Arr<A>, LanguageExt.Seq<A>> seq =
                Isomorphism<LanguageExt.Arr<A>, LanguageExt.Seq<A>>.New(
                    Get: a => a.ToSeq(),
                    Set: s => s.ToArr()
                );

            public static readonly Isomorphism<LanguageExt.Arr<A>, LanguageExt.Lst<A>> lst =
                Isomorphism<LanguageExt.Arr<A>, LanguageExt.Lst<A>>.New(
                    Get: a => a.Freeze(),
                    Set: l => l.ToArr()
                );

            public static readonly Isomorphism<LanguageExt.Arr<A>, LanguageExt.Set<A>> set =
                Isomorphism<LanguageExt.Arr<A>, LanguageExt.Set<A>>.New(
                    Get: a => new LanguageExt.Set<A>(a),
                    Set: s => s.ToArr()
                );

            public static readonly Isomorphism<LanguageExt.Arr<A>, LanguageExt.HashSet<A>> hashSet =
                Isomorphism<LanguageExt.Arr<A>, LanguageExt.HashSet<A>>.New(
                    Get: a => new LanguageExt.HashSet<A>(a),
                    Set: h => h.ToArr()
                );
        }
        
        public static class Set<A>
        {
            public static readonly Isomorphism<LanguageExt.Set<A>, A[]> array =
                Isomorphism<LanguageExt.Set<A>, A[]>.New(
                    Get: s => s.ToArray(),
                    Set: a => new LanguageExt.Set<A>(a)
                );

            public static readonly Isomorphism<LanguageExt.Set<A>, LanguageExt.Arr<A>> arr =
                Isomorphism<LanguageExt.Set<A>, LanguageExt.Arr<A>>.New(
                    Get: s => s.ToArr(),
                    Set: a => new LanguageExt.Set<A>(a)
                );

            public static readonly Isomorphism<LanguageExt.Set<A>, LanguageExt.Seq<A>> seq =
                Isomorphism<LanguageExt.Set<A>, LanguageExt.Seq<A>>.New(
                    Get: s => s.ToSeq(),
                    Set: a => new LanguageExt.Set<A>(a)
                );

            public static readonly Isomorphism<LanguageExt.Set<A>, LanguageExt.Lst<A>> lst =
                Isomorphism<LanguageExt.Set<A>, LanguageExt.Lst<A>>.New(
                    Get: s => s.Freeze(),
                    Set: a => new LanguageExt.Set<A>(a)
                );

            public static readonly Isomorphism<LanguageExt.Set<A>, LanguageExt.HashSet<A>> hashSet =
                Isomorphism<LanguageExt.Set<A>, LanguageExt.HashSet<A>>.New(
                    Get: s => new LanguageExt.HashSet<A>(s),
                    Set: h => new LanguageExt.Set<A>(h)
                );
        }

        public static class Map<K, V>
        {
            public static readonly Isomorphism<LanguageExt.Map<K, V>, (K, V)[]> array =
                Isomorphism<LanguageExt.Map<K, V>, (K, V)[]>.New(
                    Get: m => m.ToArray(),
                    Set: a => a.ToMap()
                );

            public static readonly Isomorphism<LanguageExt.Map<K, V>, LanguageExt.Arr<(K, V)>> arr =
                Isomorphism<LanguageExt.Map<K, V>, LanguageExt.Arr<(K, V)>>.New(
                    Get: m => m.ToArr(),
                    Set: a => a.ToMap()
                );

            public static readonly Isomorphism<LanguageExt.Map<K, V>, LanguageExt.Seq<(K, V)>> seq =
                Isomorphism<LanguageExt.Map<K, V>, LanguageExt.Seq<(K, V)>>.New(
                    Get: m => m.ToSeq(),
                    Set: s => s.ToMap()
                );

            public static readonly Isomorphism<LanguageExt.Map<K, V>, LanguageExt.Lst<(K, V)>> lst =
                Isomorphism<LanguageExt.Map<K, V>, LanguageExt.Lst<(K, V)>>.New(
                    Get: m => m.Freeze(),
                    Set: l => l.ToMap()
                );

            public static readonly Isomorphism<LanguageExt.Map<K, V>, LanguageExt.Set<(K, V)>> set =
                Isomorphism<LanguageExt.Map<K, V>, LanguageExt.Set<(K, V)>>.New(
                    Get: m => new LanguageExt.Set<(K, V)>(m),
                    Set: s => s.ToMap()
                );

            public static readonly Isomorphism<LanguageExt.Map<K, V>, LanguageExt.HashSet<(K, V)>> hashSet =
                Isomorphism<LanguageExt.Map<K, V>, LanguageExt.HashSet<(K, V)>>.New(
                    Get: m => new LanguageExt.HashSet<(K, V)>(m),
                    Set: h => h.ToMap()
                );

            public static readonly Isomorphism<LanguageExt.Map<K, V>, LanguageExt.HashMap<K, V>> hashMap =
                Isomorphism<LanguageExt.Map<K, V>, LanguageExt.HashMap<K, V>>.New(
                    Get: m => new LanguageExt.HashMap<K, V>(m),
                    Set: m => m.ToMap()
                );
        }

        public static class HashSet<A>
        {
            public static readonly Isomorphism<LanguageExt.HashSet<A>, A[]> array =
                Isomorphism<LanguageExt.HashSet<A>, A[]>.New(
                    Get: h => h.ToArray(),
                    Set: a => new LanguageExt.HashSet<A>(a)
                );

            public static readonly Isomorphism<LanguageExt.HashSet<A>, LanguageExt.Arr<A>> arr =
                Isomorphism<LanguageExt.HashSet<A>, LanguageExt.Arr<A>>.New(
                    Get: h => h.ToArr(),
                    Set: a => new LanguageExt.HashSet<A>(a)
                );

            public static readonly Isomorphism<LanguageExt.HashSet<A>, LanguageExt.Seq<A>> seq =
                Isomorphism<LanguageExt.HashSet<A>, LanguageExt.Seq<A>>.New(
                    Get: h => h.ToSeq(),
                    Set: a => new LanguageExt.HashSet<A>(a)
                );

            public static readonly Isomorphism<LanguageExt.HashSet<A>, LanguageExt.Lst<A>> lst =
                Isomorphism<LanguageExt.HashSet<A>, LanguageExt.Lst<A>>.New(
                    Get: h => h.Freeze(),
                    Set: a => new LanguageExt.HashSet<A>(a)
                );

            public static readonly Isomorphism<LanguageExt.HashSet<A>, LanguageExt.Set<A>> set =
                Isomorphism<LanguageExt.HashSet<A>, LanguageExt.Set<A>>.New(
                    Get: h => new LanguageExt.Set<A>(h),
                    Set: s => new LanguageExt.HashSet<A>(s)
                );
        }

        public static class HashMap<K, V>
        {
            public static readonly Isomorphism<LanguageExt.HashMap<K, V>, (K, V)[]> array =
                Isomorphism<LanguageExt.HashMap<K, V>, (K, V)[]>.New(
                    Get: m => m.ToArray(),
                    Set: a => new LanguageExt.HashMap<K, V>(a)
                );

            public static readonly Isomorphism<LanguageExt.HashMap<K, V>, LanguageExt.Arr<(K, V)>> arr =
                Isomorphism<LanguageExt.HashMap<K, V>, LanguageExt.Arr<(K, V)>>.New(
                    Get: m => m.ToArr(),
                    Set: a => new LanguageExt.HashMap<K, V>(a)
                );

            public static readonly Isomorphism<LanguageExt.HashMap<K, V>, LanguageExt.Seq<(K, V)>> seq =
                Isomorphism<LanguageExt.HashMap<K, V>, LanguageExt.Seq<(K, V)>>.New(
                    Get: m => m.ToSeq(),
                    Set: s => new LanguageExt.HashMap<K, V>(s)
                );

            public static readonly Isomorphism<LanguageExt.HashMap<K, V>, LanguageExt.Lst<(K, V)>> lst =
                Isomorphism<LanguageExt.HashMap<K, V>, LanguageExt.Lst<(K, V)>>.New(
                    Get: m => m.Freeze(),
                    Set: l => new LanguageExt.HashMap<K, V>(l)
                );

            public static readonly Isomorphism<LanguageExt.HashMap<K, V>, LanguageExt.Set<(K, V)>> set =
                Isomorphism<LanguageExt.HashMap<K, V>, LanguageExt.Set<(K, V)>>.New(
                    Get: m => new LanguageExt.Set<(K, V)>(m),
                    Set: s => new LanguageExt.HashMap<K, V>(s)
                );

            public static readonly Isomorphism<LanguageExt.HashMap<K, V>, LanguageExt.HashSet<(K, V)>> hashSet =
                Isomorphism<LanguageExt.HashMap<K, V>, LanguageExt.HashSet<(K, V)>>.New(
                    Get: m => new LanguageExt.HashSet<(K, V)>(m),
                    Set: h => new LanguageExt.HashMap<K, V>(h)
                );

            public static readonly Isomorphism<LanguageExt.HashMap<K, V>, LanguageExt.Map<K, V>> map =
                Isomorphism<LanguageExt.HashMap<K, V>, LanguageExt.Map<K, V>>.New(
                    Get: m => m.ToMap(),
                    Set: m => new LanguageExt.HashMap<K, V>(m)
                );
        }
    }
}
