using Domain.ApiResponse;
using Domain.Dtos.BookDTO;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IBookService
{
    Task<Response<string>> CreateBookAsync(CreateBookDto create);
    Task<Response<List<GetBookDto>>> GetBookAsync();
    Task<Response<string>> UpdateBookAsync(int id, UpdateBookDto update);
    Task<Response<string>> DeleteBookAsync(int id);
}