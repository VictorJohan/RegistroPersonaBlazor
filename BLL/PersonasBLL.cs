using Microsoft.EntityFrameworkCore;
using RegistroPersonaBlazor.DAL;
using RegistroPersonaBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistroPersonaBlazor.BLL
{
    public class PersonasBLL
    {
        public static async Task<bool> Guardar(Personas persona)
        {
            if (!await Existe(persona.PersonaId))
                return await Insertar(persona);
            else
                return await Modificar(persona);
        }

        public static async Task<bool> Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool ok = false;
            try
            {
                ok = await contexto.Personas.AnyAsync(p => p.PersonaId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                await contexto.DisposeAsync();
            }

            return ok;
        }

        private static async Task<bool> Insertar(Personas persona)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                await contexto.Personas.AddAsync(persona);
                ok = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                await contexto.DisposeAsync();
            }

            return ok;
        }

        private static async Task<bool> Modificar(Personas persona)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Entry(persona).State = EntityState.Modified;
                ok = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
               await contexto.DisposeAsync();
            }

            return ok;
        }

        public static async Task<Personas> Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Personas persona;

            try
            {
                persona = await contexto.Personas.FindAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                await contexto.DisposeAsync();
            }

            return persona;
        }

        public static async Task<bool> Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                var registro = await contexto.Personas.FindAsync(id);
                if(registro != null)
                {
                    contexto.Personas.Remove(registro);
                    ok = await contexto.SaveChangesAsync() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                await contexto.DisposeAsync();
            }

            return ok;
        }

        public static async Task<List<Personas>> GetPersonas()
        {
            Contexto contexto = new Contexto();
            List<Personas> lista = new List<Personas>();

            try
            {
                lista = await contexto.Personas.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                await contexto.DisposeAsync();
            }

            return lista;
        }

        public static async Task<List<Personas>> GetPersonas(Expression<Func<Personas, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Personas> lista = new List<Personas>();

            try
            {
                lista = await contexto.Personas.Where(criterio).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
               await contexto.DisposeAsync();
            }

            return lista;
        }
    }
}
