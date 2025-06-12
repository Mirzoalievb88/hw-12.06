using System.Net;
using AutoMapper;
using Domain.ApiResponse;
using Domain.Dtos.PublisherDTO;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class PublisherService(DataContext context, IMapper mapper) : IPublisherService
{
    public async Task<Response<string>> CreatePublisherAsync(CreatePublisherDto create)
    {
        var mapped = mapper.Map<Publishers>(create);
        var result = await context.Publishers.AddAsync(mapped);
        await context.SaveChangesAsync();

        if (result == null)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }

        return new Response<string>(default, "All Worked");
    }

    public async Task<Response<string>> DeletePublisherAsync(int id)
    {
        var publisher = await context.Publishers.FindAsync(id);

        if (publisher == null)
        {
            return new Response<string>("Publisher not found", HttpStatusCode.InternalServerError);
        }

        context.Publishers.Remove(publisher);

        await context.SaveChangesAsync();

        return new Response<string>(default, "All Worked");
    }   

    public async Task<Response<List<GetPublisherDto>>> GetPublisherAsync()
    {
        var publisher = await context.Publishers.ToListAsync();
        var result = mapper.Map<List<GetPublisherDto>>(publisher);

        if (result == null)
        {
            return new Response<List<GetPublisherDto>>("Result is null", HttpStatusCode.NotFound);
        }
        return new Response<List<GetPublisherDto>>(result, "All Worked");
    }

    public async Task<Response<string>> UpdatePublisherAsync(int id, UpdatePublisherDto update)
    {
        var publisher = await context.Publishers.FindAsync(id);
        if (publisher == null)
        {
            return new Response<string>("Publisher Not Found", HttpStatusCode.NotFound);
        }

        var result = mapper.Map(update, publisher);
        if (result == null)
        {
            return new Response<string>("Result is null", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(default, "All Worked");
    }
}