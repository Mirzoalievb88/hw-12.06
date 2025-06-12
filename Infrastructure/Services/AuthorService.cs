using System.Net;
using AutoMapper;
using Domain.ApiResponse;
using Domain.Dtos.AuthorDTO;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AuthorService(DataContext context, IMapper mapper) : IAuthorService
{
    public async Task<Response<string>> CreateAuthorAsync(CreateAuthorDto create)
    {
        var mapped = mapper.Map<Authors>(create);
        var result = await context.Authors.AddAsync(mapped);
        await context.SaveChangesAsync();

        if (result == null)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }

        return new Response<string>(default, "All Worked");
    }

    public async Task<Response<string>> DeleteAuthorAsync(int id)
    {
        var author = await context.Authors.FindAsync(id);

        if (author == null)
        {
            return new Response<string>("Author not found", HttpStatusCode.InternalServerError);
        }

        context.Authors.Remove(author);

        await context.SaveChangesAsync();

        return new Response<string>(default, "All Worked");
    }   

    public async Task<Response<List<GetAuthorDto>>> GetAuthorAsync()
    {
        var author = await context.Authors.ToListAsync();
        var result = mapper.Map<List<GetAuthorDto>>(author);

        if (result == null)
        {
            return new Response<List<GetAuthorDto>>("Result is null", HttpStatusCode.NotFound);
        }
        return new Response<List<GetAuthorDto>>(result, "All Worked");
    }

    public async Task<Response<string>> UpdateAuthorAsync(int id, UpdateAuthorDto update)
    {
        var author = await context.Authors.FindAsync(id);
        if (author == null)
        {
            return new Response<string>("Author Not Found", HttpStatusCode.NotFound);
        }

        var result = mapper.Map(update, author);
        if (result == null)
        {
            return new Response<string>("Result is null", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(default, "All Worked");
    }
}