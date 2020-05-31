using System;
using System.Collections;
using Microsoft.AspNetCore.Http;

namespace efcorememorytest
{
    public static class HttpContextExtensions
    {
        public static T RegisterForDispose<T>(this T disposable, HttpContext context) where T : IDisposable
        {
            context.Response.RegisterForDispose(disposable);
            return disposable;
        }

        public static void DisposeAll(this IEnumerable clx)
        {
            foreach (Object obj in clx)
            {
                IDisposable disposeable = obj as IDisposable;
                if (disposeable != null)
                    disposeable.Dispose();
            }
        }
    }
}