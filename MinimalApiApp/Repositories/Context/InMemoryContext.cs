using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Context
{
    public class InMemoryContext(DbContextOptions<InMemoryContext> options) : DbContext(options)
    {
        //public DbSet<PessoaFisica> PessoaFisicas { get; set; }

        //public DbSet<Endereco> Enderecos { get; set; }
    }
}
