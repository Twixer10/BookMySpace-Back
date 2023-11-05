using BookMySpace.Entity;
using BookMySpace.Entity.DTO;
using Microsoft.Data.SqlClient;

namespace BookMySpace.Repository.Contracts;

public interface IBookingRepository
{
    public Task<List<BookingByUserId>> GetBookingByUserId(SqlConnection sqlConnection, int userId);
}