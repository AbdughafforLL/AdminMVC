using System.Net;
namespace MVC.Models;

public class Response<T>
{
	public int StatusCode { get; set; }
	public string? Message { get; set; }
	public T? Data { get; set; }

	public Response(T data)
	{
		StatusCode = (int)HttpStatusCode.OK;
		Data = data;
	}

	public Response(HttpStatusCode code, string message)
	{
		Message = message;
		StatusCode = (int)code;
	}
}