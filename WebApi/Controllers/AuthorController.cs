using Domain.Entities;
using Domain.ApiResponse;
using Domain.Dtos.AuthorDTO;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AuthorController(IAuthorService authorService)
{
    [HttpGet]
    public async Task<Response<List<GetAuthorDto>>> GetAuthorAsync()
    {
        return await authorService.GetAuthorAsync();
    }

    [HttpPost]
    public async Task<Response<string>> CreateAuthorAsync(CreateAuthorDto create)
    {
        return await authorService.CreateAuthorAsync(create);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateAuthorAsync(int id, UpdateAuthorDto update)
    {
        return await authorService.UpdateAuthorAsync(id, update);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteAuthorAsync(int id)
    {
        return await authorService.DeleteAuthorAsync(id);
    }
}