using CocktailDebacleBackend.Dtos.User;
using CocktailDebacleBackend.Models;

namespace CocktailDebacleBackend.Mappers
{
    public static class UserMappers 
    {
        public static UserDto ToUserDto(this UserDto userModel)
        {
            return new UserDto
            {
                UserId = userModel.UserId,
                Username = userModel.Username,
                Email = userModel.Email,
                ConsentProfile = userModel.ConsentProfile,
                CreatedAt = userModel.CreatedAt
            };
        }

        public static User ToUserFromCreateDTO(this CreateUserRequestDto createUserRequestDto)
		{
			return new User
			{
				Username = createUserRequestDto.Username,
				Email = createUserRequestDto.Email,
				PasswordHash = createUserRequestDto.Password,
				ConsentProfile = createUserRequestDto.ConsentProfile
			};
		}
	}
}
