﻿using MockInterview.Domain.Models;
using MockInterview.Domain.Models.EmployeeDTO;

namespace MockInterview.Business.Interface
{
    public interface IEmployeeServiceAsync : IGenericServiceAsync<EmployeeDTO>
    {
        Task<HttpResponse<string>> LoginAsync(LoginModel login);
    }
}
