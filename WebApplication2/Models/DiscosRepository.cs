using Microsoft.EntityFrameworkCore;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class DiscosRepository
    {
        internal List<Disco> Retrieve()
        {

            List<Disco> discos = new List<Disco>();
            using (DiscosContext context = new DiscosContext())
            {
                discos = context.Discos.ToList();
            }

            return discos;

        }

        internal Disco Retrieve(int id)
        {
            Disco disco;

            using (DiscosContext context = new DiscosContext())
            {
                disco = context.Discos
                    .Where(s => s.DiscoId == id)
                    .FirstOrDefault();
            }


            return disco;
        }
        
        internal void Save(Disco d)
        {                       
            DiscosContext context = new DiscosContext();

            Grupo grupo = context.Grupos
                .Where(g => g.GrupoId == d.GrupoId)
                .FirstOrDefault();

            d.Grupo = grupo;
            context.Discos.Add(d);
            context.SaveChanges();            

        }
        
    }
}