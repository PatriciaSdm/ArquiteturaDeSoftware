﻿using DemoDI.Cases;
using Microsoft.AspNetCore.Mvc;

namespace DemoDI.Controllers
{
    public class FromServicesController : Controller
    {
        //Evitar o uso
        public void Index([FromServices] IClienteServices clienteServices)
        {
            clienteServices.AdicionarCliente(new Cliente());
        }
    }
}