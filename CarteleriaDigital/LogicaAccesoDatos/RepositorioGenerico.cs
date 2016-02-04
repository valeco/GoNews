using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CarteleriaDigital.LogicaAccesoDatos
{
    public class RepositorioGenerico<TEntity> where TEntity : class
    {
        internal DbSet<TEntity> dbSet;
        internal CarteleriaContext iContext;

        /// <summary>
        ///     Inicializa una nueva instancia de RepositorioGenerico.
        /// </summary>
        /// <param name="pContext">Contexto a utilizar.</param>
        public RepositorioGenerico(CarteleriaContext pContext)
        {
            this.iContext = pContext;
            this.dbSet = iContext.Set<TEntity>();
        }

        /// <summary>
        ///     Develve el DbSet del repositorio.
        /// </summary>
        public IQueryable<TEntity> Queryable
        {
            get { return dbSet; }
        }

        /// <summary>
        ///     Obtiene un objeto del repositorio a través de su ID.
        /// </summary>
        /// <param name="id">ID del objeto.</param>
        /// <returns>Objeto cuyo ID es el suministrado.</returns>
        public virtual TEntity ObtenerPorId(int id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        ///     Inserta un objeto en el repositorio.
        /// </summary>
        /// <param name="entity">Objeto a insertar.</param>
        public virtual void Insertar(TEntity entity)
        {
            dbSet.Add(entity);
        }

        /// <summary>
        ///     Elimina un objeto del repositorio a través de su ID.
        /// </summary>
        /// <param name="id">ID del objeto a eliminar.</param>
        public virtual void Eliminar(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Eliminar(entityToDelete);
        }

        /// <summary>
        ///     Elimina un objeto del respositorio.
        /// </summary>
        /// <param name="entidadABorrar">Objeto a eliminar.</param>
        public void Eliminar(TEntity entidadABorrar)
        {
            if (iContext.Entry(entidadABorrar).State == EntityState.Detached)
            {
            	dbSet.Attach(entidadABorrar);
            }

            dbSet.Remove(entidadABorrar);
        }

        /// <summary>
        ///     Modifica un objeto del respositorio.
        /// </summary>
        /// <param name="entidadAModificar">Objeto modificado.</param>
        public void Modificar(TEntity entidadAModificar)
        {
        	dbSet.Attach(entidadAModificar);
            iContext.Entry(entidadAModificar).State = EntityState.Modified;
        }
    }
}
