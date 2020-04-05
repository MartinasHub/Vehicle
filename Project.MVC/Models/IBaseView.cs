using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.MVC.Models
{
    public interface IBaseView
    {
        int Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
    }
}