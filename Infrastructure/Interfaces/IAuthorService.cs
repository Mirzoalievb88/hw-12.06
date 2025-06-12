using Domain.ApiResponse;
using Domain.Dtos.AuthorDTO;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IAuthorService
{
    Task<Response<string>> CreateAuthorAsync(CreateAuthorDto create);
    Task<Response<List<GetAuthorDto>>> GetAuthorAsync();
    Task<Response<string>> UpdateAuthorAsync(int id, UpdateAuthorDto update);
    Task<Response<string>> DeleteAuthorAsync(int id);
}