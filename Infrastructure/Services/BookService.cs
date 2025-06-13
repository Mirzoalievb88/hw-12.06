using System.Net;
using AutoMapper;
using Domain.ApiResponse;
using Domain.Dtos.BookDTO;
using Domain.Entities;
using Domain.Filters;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class BookService(DataContext context, IMapper mapper) : IBookService
{
    public async Task<Response<string>> CreateBookAsync(CreateBookDto create)
    {
        var mapped = mapper.Map<Books>(create);
        var result = await context.Books.AddAsync(mapped);
        await context.SaveChangesAsync();

        if (result == null)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }

        return new Response<string>(default, "All Worked");
    }

    public async Task<Response<string>> DeleteBookAsync(int id)
    {
        var book = await context.Books.FindAsync(id);

        if (book == null)
        {
            return new Response<string>("Book not found", HttpStatusCode.InternalServerError);
        }

        context.Books.Remove(book);

        await context.SaveChangesAsync();

        return new Response<string>(default, "All Worked");
    }   

    public async Task<Response<List<GetBookDto>>> GetBookAsync(BookFilter filter)
    {
        var validFilter = new ValidFilter(filter.PageNumber, filter.PageSize);

        var query = context.Books.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Title))
        {
            query = query.Where(b => b.Title.ToLower().Trim().Contains(filter.Title.ToLower().Trim()));
        }

        if (filter.MinPrice != null)
        {
            query = query.Where(b => b.Price >= filter.MinPrice);
        }

        if (filter.MaxPrice != null)
        {
            query = query.Where(b => b.Price <= filter.MaxPrice);
        }

        var totalRecords = await query.CountAsync();

        var paged = await query
            .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
            .Take(validFilter.PageSize)
            .ToListAsync();

        var mapped = mapper.Map<List<GetBookDto>>(paged);


        return new PagedResponse<List<GetBookDto>>(mapped, totalRecords, validFilter.PageNumber, validFilter.PageSize);
    }

    public async Task<Response<string>> UpdateBookAsync(int id, UpdateBookDto update)
    {
        var book = await context.Books.FindAsync(id);
        if (book == null)
        {
            return new Response<string>("Book Not Found", HttpStatusCode.NotFound);
        }

        var result = mapper.Map(update, book);
        if (result == null)
        {
            return new Response<string>("Result is null", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(default, "All Worked");
    }
}