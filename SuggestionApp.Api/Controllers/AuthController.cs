using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SuggestionApp.Api.Dtos.AuthDtos;
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

        [HttpPost(Routes.Auth.Register)]
        public async Task<ActionResult<RegisterResponse>> Register([FromBody] RegisterRequest registerRequest)
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
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest loginRequest)
        {
            await _loginRequestValidator
                .ValidateAndThrowAsync(loginRequest);

            var (status, value) = await _identityService
                .Login(loginRequest.ToApplicationDto());

            if (status is not LoginStatus.Success)
                return BadRequest();

            return Ok(value!.ToDto());
        }
    }
}