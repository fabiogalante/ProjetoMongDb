﻿using Microsoft.AspNetCore.Mvc;
using ProjetoMongDb.Application;

namespace ProjetoMongDb.API.Controllers
{
    public abstract class BasePresenter<T> where T : Result
    {
        public IActionResult ViewModel { get; protected set; }

        public void Popular(T resultado)
        {
            if (resultado == null || resultado.Error == ErrorCode.NotFound)
            {
                ViewModel = new NotFoundObjectResult(ApiError.FromResult(resultado));
                return;
            }

            if (resultado.Invalid)
            {
                ViewModel = new UnprocessableEntityObjectResult(ApiError.FromResult(resultado));
                return;
            }

            OnPopular(resultado);
        }

        protected abstract void OnPopular(T resultado);
    }
}
