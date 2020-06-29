using System;
using DemoDI.Cases;
using Microsoft.AspNetCore.Mvc;

namespace DemoDI.Controllers
{
    public class MultiplasClassesController : Controller
    {
        //Evitar o uso, principio de Liskov
        //Uma interface deveria ser para apenas uma classe
        private readonly Func<string, IService> _serviceAccessor;

        public MultiplasClassesController(Func<string, IService> serviceAccessor)
        {
            _serviceAccessor = serviceAccessor;
        }

        public string Index()
        {
            return _serviceAccessor("A").Retorno();
            //return _serviceAccessor("B").Retorno();
            //return _serviceAccessor("C").Retorno();
        }
    }
}
