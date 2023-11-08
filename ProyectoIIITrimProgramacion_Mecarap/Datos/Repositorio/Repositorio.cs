using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio;

namespace ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repositorio(ApplicationDbContext db)
        {
            this._db = db;
            this.dbSet = _db.Set<T>();
        }

        void IRepositorio<T>.Agregar(T entidad)
        {
            dbSet.Add(entidad);

        }

        void IRepositorio<T>.Grabar()
        {
            _db.SaveChanges();
        }

        T IRepositorio<T>.Obtener(int id)
        {
            return dbSet.Find(id);
        }

        public T ObtenerPrimero(Expression<Func<T, bool>> filtro = null, string incluirPropiedades = null, bool isTracking = true)
        {
            //throw new NotImplementedException();

            IQueryable<T> query = dbSet;

            if (filtro != null)
            {
                query = query.Where(filtro);
            }
            if (incluirPropiedades != null)
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))//por cada string que se genere vamos a incluir un include
                {
                    query = query.Include(incluirProp);//eje "Categoria,TipoAplicacion"
                }

            }

            if (!isTracking)
            {
                query = query.AsNoTracking();

            }
            return query.FirstOrDefault();//aca  no retorna una lista , sino un registro
        }



        public IEnumerable<T> ObtenerTodos(Expression<Func<T, bool>> filtro = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string incluirPropiedades = null, bool isTracking = true)
        {
            //  throw new NotImplementedException();


            IQueryable<T> query = dbSet;

            if (filtro != null)
            {
                query = query.Where(filtro);
            }
            if (incluirPropiedades != null)
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))//por cada string que se genere vamos a incluir un include
                {
                    query = query.Include(incluirProp);//eje "Categoria,TipoAplicacion"
                }

            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (!isTracking)
            {
                query = query.AsNoTracking();

            }

            return query.ToList();

        }

        public void RemoverRango(IEnumerable<T> entidad)
        {
            dbSet.RemoveRange(entidad);
        }

        void IRepositorio<T>.Remover(T entidad)
        {
            dbSet.Remove(entidad);
        }
    }
}
