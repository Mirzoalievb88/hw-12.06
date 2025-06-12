using Domain.ApiResponse;
using Domain.Dtos.EditorDTO;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IEditorService
{
    Task<Response<string>> CreateEditorAsync(CreateEditorDto create);
    Task<Response<List<GetEditorDto>>> GetEditorAsync();
    Task<Response<string>> UpdateEditorAsync(int id, UpdateEditorDto update);
    Task<Response<string>> DeleteEditorAsync(int id);
}