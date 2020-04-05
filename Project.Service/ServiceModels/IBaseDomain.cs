using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Service.ServiceModels
{
    public interface IBaseDomain
    {
        int Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
    }
}