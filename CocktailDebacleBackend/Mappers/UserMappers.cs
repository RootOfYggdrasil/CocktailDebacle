using CocktailDebacleBackend.Dtos.User;
using CocktailDebacleBackend.Models;

namespace CocktailDebacleBackend.Mappers
{
    public static class UserMappers 
    {
        public static UserDto ToUserDto(this User userModel)
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
		public static User ToUserFromUpdateDTO(this UpdateUserRequestDto updateUserRequestDto)
		{
			return new User
			{
				Username = updateUserRequestDto.Username,
				Email = updateUserRequestDto.Email,
				PasswordHash = updateUserRequestDto.Password,
				ConsentProfile = updateUserRequestDto.ConsentProfile
			};
		}
	}
}
