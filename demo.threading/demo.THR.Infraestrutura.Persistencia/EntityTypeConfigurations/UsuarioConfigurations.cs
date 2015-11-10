using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.THR.Dominio.Entities;

namespace demo.THR.Infraestrutura.Persistencia.EntityTypeConfigurations
{
    public class UsuarioConfigurations : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfigurations()
        {
            Property(x => x.CPF.Numero)
                .HasColumnName("Cpf")
                .HasColumnAnnotation(IndexAnnotation.Annotation, 
                new IndexAnnotation(new IndexAttribute("IX_CPF", 1)(IsUnique = true)));
        }
    }
}