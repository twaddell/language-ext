using System;
using static LanguageExt.Prelude;

namespace LanguageExt
{
    public static partial class Optics
    {
        public static class Result<A>
        {
            public static Prism<LanguageExt.Common.Result<A>, Exception> fail
                => Prism<LanguageExt.Common.Result<A>, Exception>.New(
                    Get: result => result.Match(Fail: Some, Succ: _ => None),
                    Set: exception => _ => new LanguageExt.Common.Result<A>(exception)
                );

            public static Prism<LanguageExt.Common.Result<A>, A> succ
                => Prism<LanguageExt.Common.Result<A>, A>.New(
                    Get: result => result.Match(Fail: _ => None, Succ: Some),
                    Set: a => _ => new LanguageExt.Common.Result<A>(a)
                );
        }
    }
}
