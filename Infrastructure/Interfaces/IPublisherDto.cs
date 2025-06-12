using Domain.ApiResponse;
using Domain.Dtos.PublisherDTO;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IPublisherService
{
    Task<Response<string>> CreatePublisherAsync(CreatePublisherDto create);
    Task<Response<List<GetPublisherDto>>> GetPublisherAsync();
    Task<Response<string>> UpdatePublisherAsync(int id, UpdatePublisherDto update);
    Task<Response<string>> DeletePublisherAsync(int id);
}