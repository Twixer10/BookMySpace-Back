using BookMySpace.Entity;
using BookMySpace.Entity.DTO;
using BookMySpace.Repository.Contracts;
using BookMySpace.Services.Contracts;
using Microsoft.Data.SqlClient;


public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    
    public BookingService(IBookingRepository bookingRepository)
    {
        this._bookingRepository = bookingRepository;
    }
    
    public async Task<List<BookingByUserId>> GetBookingByUserId(SqlConnection sqlConnection, int userId)
    {
        return await this._bookingRepository.GetBookingByUserId(sqlConnection, userId);
    }
}