using System.Net;
using AutoMapper;
using Domain.ApiResponse;
using Domain.Dtos.EditorDTO;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class EditorService(DataContext context, IMapper mapper) : IEditorService
{
    public async Task<Response<string>> CreateEditorAsync(CreateEditorDto create)
    {
        var mapped = mapper.Map<Editors>(create);
        var result = await context.Editors.AddAsync(mapped);
        await context.SaveChangesAsync();

        if (result == null)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }

        return new Response<string>(default, "All Worked");
    }

    public async Task<Response<string>> DeleteEditorAsync(int id)
    {
        var editor = await context.Editors.FindAsync(id);

        if (editor == null)
        {
            return new Response<string>("Editor not found", HttpStatusCode.InternalServerError);
        }

        context.Editors.Remove(editor);

        await context.SaveChangesAsync();

        return new Response<string>(default, "All Worked");
    }   

    public async Task<Response<List<GetEditorDto>>> GetEditorAsync()
    {
        var Editor = await context.Editors.ToListAsync();
        var result = mapper.Map<List<GetEditorDto>>(Editor);

        if (result == null)
        {
            return new Response<List<GetEditorDto>>("Result is null", HttpStatusCode.NotFound);
        }
        return new Response<List<GetEditorDto>>(result, "All Worked");
    }

    public async Task<Response<string>> UpdateEditorAsync(int id, UpdateEditorDto update)
    {
        var editor = await context.Editors.FindAsync(id);
        if (editor == null)
        {
            return new Response<string>("Editor Not Found", HttpStatusCode.NotFound);
        }

        var result = mapper.Map(update, editor);
        if (result == null)
        {
            return new Response<string>("Result is null", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(default, "All Worked");
    }
}