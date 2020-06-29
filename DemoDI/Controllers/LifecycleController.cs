using System;
using DemoDI.Cases;
using Microsoft.AspNetCore.Mvc;

namespace DemoDI.Controllers
{
    public class LifecycleController : Controller
    {
        public OperacaoService OperacaoService { get; }
        public OperacaoService OperacaoService2 { get; }

        public LifecycleController(OperacaoService operacaoService, OperacaoService operacaoService2)
        {
            OperacaoService = operacaoService;
            OperacaoService2 = operacaoService2;
        }

        public string Index()
        {

            //            return $@"PRIMEIRA INSTÂNCIA:, { Environment.NewLine}
            //Transient: {OperacaoService.Transient.OperacaoId + Environment.NewLine}
            //Scoped: {OperacaoService.Transient.OperacaoId + Environment.NewLine}
            //Singleton: {OperacaoService.Transient.OperacaoId + Environment.NewLine}
            //Transient: {OperacaoService.Transient.OperacaoId + Environment.NewLine}
            //                   Transient: {OperacaoService.Transient.OperacaoId + Environment.NewLine}";

            return
                $@"
                PRIMEIRA INSTÂNCIA: { Environment.NewLine}
                {"Transient:",-20}  {OperacaoService.Transient.OperacaoId + Environment.NewLine} 
                {"Scoped:",-20}  { OperacaoService.Scoped.OperacaoId + Environment.NewLine}
                {"Singleton:",-20}  { OperacaoService.Singleton.OperacaoId + Environment.NewLine} 
                {"SingletonInstance:",-20}  { OperacaoService.SingletonInstance.OperacaoId + Environment.NewLine +

                Environment.NewLine + Environment.NewLine}

                SEGUNDA INSTÂNCIA: { Environment.NewLine} 
                {"Transient:",-20} { OperacaoService2.Transient.OperacaoId + Environment.NewLine } 
                {"Scoped:",-20} { OperacaoService2.Scoped.OperacaoId + Environment.NewLine }
                {"Singleton:",-20} { OperacaoService2.Singleton.OperacaoId + Environment.NewLine} 
                {"SingletonInstance:",-20} { OperacaoService2.SingletonInstance.OperacaoId + Environment.NewLine}".ToString();
        }
    }
}
