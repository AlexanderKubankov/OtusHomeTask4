using System.Net;

namespace Api.Infrastructure
{
    /// <summary>Обработчик ошибок.</summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        /// <summary>Создать экземпляр <see cref="ErrorHandlingMiddleware"/>.</summary>
        /// <param name="next"><see cref="RequestDelegate"/>.</param>
        /// <param name="container">Контейнер зависимостей.</param>
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>Выполнить.</summary>
        /// <param name="context"><see cref="HttpContext"/>.</param>
        /// <returns><see cref="Task"/>.</returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (NotImplementedException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotImplemented;
            }
            catch (FileNotFoundException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
        }
    }
}