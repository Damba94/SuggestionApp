using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuggestionApp.Api.Dtos.AuthDtos;
using SuggestionApp.Api.Extensions;
using SuggestionApp.Application.Constants;
using SuggestionApp.Application.Enums;
using SuggestionApp.Application.Interfaces;
using SuggestionApp.Data.Enums;

namespace SuggestionApp.Api.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IValidator<RegisterRequest> _registerRequestValidator;
        private readonly IValidator<LoginRequest> _loginRequestValidator;
        private readonly IIdentityService _identityService;

        public AuthController(
            IValidator<RegisterRequest> registerRequestValidator,
            IIdentityService identityService,
            IValidator<LoginRequest> loginRequestValidator)
        {
            _registerRequestValidator = registerRequestValidator;
            _identityService = identityService;
            _loginRequestValidator = loginRequestValidator;

        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost(Routes.Auth.Register)]
        public async Task<ActionResult<RegisterResponse>> Register(
            [FromBody] RegisterRequest registerRequest)
        {
            await _registerRequestValidator
                .ValidateAndThrowAsync(registerRequest);

            var (status, value) = await _identityService
                .UserRegister(registerRequest.ToApplicationDto());

            if (status is not RegistrationStatus.Registered)
                return BadRequest();

            return Ok(value!.ToDto());
        }

        [HttpPost(Routes.Auth.Login)]
        public async Task<ActionResult<LoginResponse>> Login(
            [FromBody] LoginRequest loginRequest)
        {
            await _loginRequestValidator
                .ValidateAndThrowAsync(loginRequest);

            var (status, value) = await _identityService
                .Login(loginRequest.ToApplicationDto());

            if (status is not LoginStatus.Success)
                return BadRequest();

            return Ok(value!.ToDto());
        }

        [HttpPost(Routes.Auth.RefreshToken)]
        public async Task<ActionResult<LoginResponse>> Refreshtoken(
            [FromBody] RefreshTokenRequest refreshTokenRequest)
        {
            var mappedRequest = refreshTokenRequest
                .ToApplicationDto(User.GetUserId());

            var (status,value)= await _identityService
                .RefreshToken(mappedRequest);

            return status switch
            {
                RefreshTokenStatus.Success => Ok(value),

                RefreshTokenStatus.UserNotFound => NotFound("Korisnik nije pronađen."),

                RefreshTokenStatus.TokenNotFound => Unauthorized("Refresh token nije pronađen."),

                RefreshTokenStatus.TokenExpired => Unauthorized("Refresh token je istekao."),

                RefreshTokenStatus.TokenAlreadyUsed => Unauthorized("Refresh token je već iskorišten."),

                RefreshTokenStatus.Error => StatusCode(500, "Došlo je do interne greške."),

                _ => StatusCode(500, "Nepoznata greška.")
            };

        }
    }
}
