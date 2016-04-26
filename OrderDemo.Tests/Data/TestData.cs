using OrderDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDemo.Tests
{
	public class TestData
	{
		public static IQueryable<Product> Products {

			get {
				var products = new List<Product>();

				for (int i = 1; i <= 10; i++) {
					var product = new Product();
					product.Id = i;
					product.Name = "Product_" + i;
					products.Add(product);
				}

				return products.AsQueryable();
			}
		}
	}
}
