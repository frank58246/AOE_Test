using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AOE_Test.Services
{
    public interface IFooService
    {
        string Echo(string value);
    }

    public class FooService : IFooService
    {
        public string Echo(string value)
        {
            return value;
        }
    }

    public class DecoFooService : IFooService
    {
        private readonly IFooService _fooService;

        public DecoFooService(IFooService fooService)
        {
            _fooService = fooService;
        }

        public string Echo(string value)
        {
            return "Decorate " + this._fooService.Echo(value);
        }
    }
}