using MyCQRS.Domain.Photographers;
using System.Collections.Generic;

namespace MyCQRS.Infra.Data
{
    public static class FakeDatabase
    {
        public static List<Photographer> Photographers { get; set; } = new List<Photographer>();
    }
}