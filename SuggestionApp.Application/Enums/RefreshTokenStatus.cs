using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionApp.Application.Enums
{
    public enum RefreshTokenStatus
    {
        Success,
        TokenNotFound,
        TokenExpired,
        TokenAlreadyUsed,
        UserNotFound,
        DatabaseError,
        Error
    }

}
