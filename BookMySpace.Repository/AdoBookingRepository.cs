using BookMySpace.Entity;
using BookMySpace.Entity.DTO;
using BookMySpace.Repository.Contracts;
using Microsoft.Data.SqlClient;

namespace BookMySpace.Repository;

public class AdoBookingRepository : IBookingRepository
{
    public async Task<List<BookingByUserId>> GetBookingByUserId(SqlConnection sqlConnection, int userId)
    {

        SqlCommand command = new SqlCommand("SELECT * FROM GetUserBookings(@userId)", sqlConnection);

        command.Parameters.AddWithValue("@userId", userId);

        await sqlConnection.OpenAsync();

        SqlDataReader reader = await command.ExecuteReaderAsync();
        
        var bookingByUserIdList = new List<BookingByUserId>();

        while (await reader.ReadAsync())
        {
            bookingByUserIdList.Add(new BookingByUserId()
            {
                Id = (int)reader["BookingId"],
                Name = (string)reader["SpaceName"],
                url = (string)reader["SpaceImageURL"],
            });
        }
        await sqlConnection.CloseAsync();

        return bookingByUserIdList;
    }
}