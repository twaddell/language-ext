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
                    Get: a => a,
                    Set: a => _ => Some(a)
                );

            public static Prism<LanguageExt.Option<A>, Unit> none
                => Prism<LanguageExt.Option<A>, Unit>.New(
                    Get: a => a.Match(
                        Some: _ => LanguageExt.Option<Unit>.None,
                        None: () => Unit.Default),
                    Set: _ => _ => None
                );
        }

        public static class Either<L, R>
        {
            public static Prism<LanguageExt.Either<L, R>, L> left
                => Prism<LanguageExt.Either<L, R>, L>.New(
                    Get: a => a.Match(Left: Some, Right: _ => None),
                    Set: a => _ => Left(a)
                );

            public static Prism<LanguageExt.Either<L, R>, R> right
                => Prism<LanguageExt.Either<L, R>, R>.New(
                    Get: a => a.Match(Left: _ => None, Right: Some),
                    Set: a => _ => Right(a)
                );
        }

        public static class Fin<A>
        {
            public static Prism<LanguageExt.Fin<A>, Error> fail
                => Prism<LanguageExt.Fin<A>, Error>.New(
                    Get: a => a.Match(Fail: Some, Succ: _ => None),
                    Set: a => _ => LanguageExt.Fin<A>.Fail(a)
                );

            public static Prism<LanguageExt.Fin<A>, A> succ
                => Prism<LanguageExt.Fin<A>, A>.New(
                    Get: a => a.Match(Fail: _ => None, Succ: Some),
                    Set: a => _ => LanguageExt.Fin<A>.Succ(a)
                );
        }

        public static class Validation<MonoidFail, FAIL, SUCCESS>
            where MonoidFail : struct, Monoid<FAIL>, Eq<FAIL>
        {
            public static Prism<LanguageExt.Validation<MonoidFail, FAIL, SUCCESS>, FAIL> fail
                => Prism<LanguageExt.Validation<MonoidFail, FAIL, SUCCESS>, FAIL>.New(
                    Get: a => a.Match(Fail: Some, Succ: _ => None),
                    Set: a => _ => LanguageExt.Validation<MonoidFail, FAIL, SUCCESS>.Fail(a)
                );

            public static Prism<LanguageExt.Validation<MonoidFail, FAIL, SUCCESS>, SUCCESS> success
                => Prism<LanguageExt.Validation<MonoidFail, FAIL, SUCCESS>, SUCCESS>.New(
                    Get: a => a.Match(Fail: _ => None, Succ: Some),
                    Set: a => _ => LanguageExt.Validation<MonoidFail, FAIL, SUCCESS>.Success(a)
                );
        }
    }
}
