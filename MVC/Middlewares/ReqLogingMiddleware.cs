namespace MVC.Middlewares;
public class ReqLogingMiddleware(RequestDelegate next, ILogger<ReqLogingMiddleware> logger)
{
	public async Task Invoke(HttpContext context)
	{

		foreach (var header in context.Request.Headers)
			logger.LogInformation("Header: {Key}: {Value}", header.Key, header.Value);
		await next(context);
	}
}