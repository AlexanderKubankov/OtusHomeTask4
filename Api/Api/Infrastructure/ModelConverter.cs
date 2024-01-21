using Api.Data.Models;
using Api.Models;

namespace Api.Infrastructure
{
    public static class ModelConverter
    {
        public static UserResponse ToUserResponse(this User user)
            => new UserResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Email = user.Email,
                Phone = user.Phone,
            };

        public static CreateUserResponse ToCreateUserResponse(this User user)
            => new CreateUserResponse
            {
                Id = user.Id,
            };

        public static void SetFrom(this User user, UserRequest request)
        {
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Username = request.Username;
            user.Email = request.Email;
            user.Phone = request.Phone;
        }
    }
}
