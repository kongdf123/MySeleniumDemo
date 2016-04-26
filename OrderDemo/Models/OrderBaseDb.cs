using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OrderDemo.Models
{
	public interface IOrderBaseDb : IDisposable
	{
		IQueryable<T> Query<T>() where T : class;
		void Add<T>(T entity) where T : class;
		void Update<T>(T entity) where T : class;
		void Remove<T>(T entity) where T : class;
		void SaveChanges();
	}

	public class OrderBaseDb : DbContext, IOrderBaseDb
	{
		public OrderBaseDb() : base("name=DefaultConnection") {

		}

		public DbSet<Product> Products { get; set; }

		public void Add<T>(T entity) where T : class {
			Set<T>().Add(entity);
		}

		public void Remove<T>(T entity) where T : class {
			Set<T>().Remove(entity);
		}

		public void Update<T>(T entity) where T : class {
			Entry(entity).State = EntityState.Modified;
		}

		IQueryable<T> IOrderBaseDb.Query<T>() {
			return Set<T>();
		}

		void IOrderBaseDb.SaveChanges() {
			SaveChanges();
		}
	}
}