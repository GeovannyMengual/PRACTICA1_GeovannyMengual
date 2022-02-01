using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace PeliMex.Entities

{
    public class films
    {
         public int Id { get; set; }
         public string Titulo { get; set; }
         public string Director { get; set; }
         public string Genero { get; set; }
         public double Puntuacion { get; set; }
         public double Rating { get; set; }
         public int Anio { get; set; }
    }
}