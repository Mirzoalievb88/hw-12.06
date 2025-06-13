using System.Net;

namespace Domain.ApiResponse;

public class Response<T>
{
    private T? data;
    private string message;
    private T? data1;

    public bool IsSuccesed { get; set; }
    public T Data { get; set; }
    public string Massege { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    public Response(string massege, HttpStatusCode statusCode)
    {
        IsSuccesed = false;
        Data = default;
        Massege = massege;
        StatusCode = statusCode;
    }

    public Response(T data, string massege)
    {
        IsSuccesed = true;
        Data = data;
        Massege = massege;
        StatusCode = HttpStatusCode.OK;
    }
}