using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login_Proyect.NetMVC.Models
{
    public class ReclutamientoUsuariosDBContext:DbContext
    {

        public ReclutamientoUsuariosDBContext(DbContextOptions<ReclutamientoUsuariosDBContext>options) : base(options)
        {


        }

        public DbSet<Usuario> Usuario { get; set; }



    }
}
