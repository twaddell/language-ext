using LanguageExt.Common;
using LanguageExt.TypeClasses;
using static LanguageExt.Prelude;

namespace LanguageExt
{
    public static partial class Optics
    {
        public static class Option<A>
        {
            public static Prism<LanguageExt.Option<A>, A> some
                => Prism<LanguageExt.Option<A>, A>.New(
                    Get: option => option,
                    Set: a => _ => a
                );

            public static Prism<LanguageExt.Option<A>, Unit> none
                => Prism<LanguageExt.Option<A>, Unit>.New(
                    Get: option => option.Match(
                        Some: _ => None,
                        None: () => Some(Unit.Default)),
                    Set: _ => _ => None
                );
        }

        public static class Either<L, R>
        {
            public static Prism<LanguageExt.Either<L, R>, L> left
                => Prism<LanguageExt.Either<L, R>, L>.New(
                    Get: either => either.Match(Left: Some, Right: _ => None),
                    Set: l => _ => Left(l)
                );

            public static Prism<LanguageExt.Either<L, R>, R> right
                => Prism<LanguageExt.Either<L, R>, R>.New(
                    Get: either => either.Match(Left: _ => None, Right: Some),
                    Set: r => _ => Right(r)
                );
        }

        public static class Fin<A>
        {
            public static Prism<LanguageExt.Fin<A>, Error> fail
                => Prism<LanguageExt.Fin<A>, Error>.New(
                    Get: fin => fin.Match(Fail: Some, Succ: _ => None),
                    Set: err => _ => LanguageExt.Fin<A>.Fail(err)
                );

            public static Prism<LanguageExt.Fin<A>, A> succ
                => Prism<LanguageExt.Fin<A>, A>.New(
                    Get: fin => fin.Match(Fail: _ => None, Succ: Some),
                    Set: a => _ => LanguageExt.Fin<A>.Succ(a)
                );
        }

        public static class Validation<MonoidFail, FAIL, SUCCESS>
            where MonoidFail : struct, Monoid<FAIL>, Eq<FAIL>
        {
            public static Prism<LanguageExt.Validation<MonoidFail, FAIL, SUCCESS>, FAIL> fail
                => Prism<LanguageExt.Validation<MonoidFail, FAIL, SUCCESS>, FAIL>.New(
                    Get: validation => validation.Match(Fail: Some, Succ: _ => None),
                    Set: f => _ => LanguageExt.Validation<MonoidFail, FAIL, SUCCESS>.Fail(f)
                );

            public static Prism<LanguageExt.Validation<MonoidFail, FAIL, SUCCESS>, SUCCESS> success
                => Prism<LanguageExt.Validation<MonoidFail, FAIL, SUCCESS>, SUCCESS>.New(
                    Get: validation => validation.Match(Fail: _ => None, Succ: Some),
                    Set: s => _ => LanguageExt.Validation<MonoidFail, FAIL, SUCCESS>.Success(s)
                );
        }
    }
}
