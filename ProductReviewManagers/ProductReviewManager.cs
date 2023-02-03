using ProductReviewManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProductReviewManagers
{
    public class ProductReviewManager
    {
        public static List<ProductReview> AddProductReviewToList(List<ProductReview> products)
        {
            try
            {
                products.Add(new ProductReview() { ProductId = 1, UserId =2, Review ="Very Good", Rating = 5, IsLike=true});
                products.Add(new ProductReview() { ProductId = 2, UserId = 1, Review = "Good", Rating = 2.5, IsLike = false });
                products.Add(new ProductReview() { ProductId = 3, UserId = 3, Review = "Satisfactory", Rating = 3, IsLike = false });
                products.Add(new ProductReview() { ProductId = 4, UserId = 2, Review = "Very Good", Rating = 4.5, IsLike = true });
                products.Add(new ProductReview() { ProductId = 5, UserId = 4, Review = "Poor", Rating = 2, IsLike = false });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return products;
        }

         public static void IterateList(List<ProductReview> products)
         {
             foreach(ProductReview product in products)
             {
               Console.WriteLine(product);
             }
         }

        public static List<ProductReview> RetrieveTopThree(List<ProductReview> products)
        {
            var productRating = products.OrderByDescending(p=>p.Rating).Take(3).ToList();
            Console.WriteLine("Printing top 3 records:");
            IterateList(productRating); 
            return productRating;

        }

        public static List<ProductReview> RetrieveParticularData(List<ProductReview> products)
        {
          var productRating = (from product in products where (product.ProductId == 1 || product.ProductId == 4 || product.ProductId == 9) && product.Rating>3 select product).ToList();
          Console.WriteLine("Printing top 3 records:");
          IterateList(productRating);
          return productRating;
        }

        public static int RetrieveProductReviewCount(List<ProductReview> products)
        {
            int PCCount = 0;
            var resProductCount = products.GroupBy(o=>o.ProductId).Select(p=> new {productId=p.Key, count = p.Count()});
            Console.WriteLine("Printing all reviews");
            foreach(var product in resProductCount)
            {
                Console.WriteLine($"Product Id: {product.productId} Count:{product.count}");
                PCCount++;
            }
            return PCCount;

        }

        public static List<ProductReview> SkipTopThree(List<ProductReview> products)
        {
            var productRating = (from p in products orderby p.Rating ascending select p).Skip(3).ToList();
            Console.WriteLine("Skiping top 3 records:");
            IterateList(productRating);
            return productRating;
        }


        public static DataTable CreateTable(List<ProductReview> products)
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("ProductId", typeof(int));
            dataTable.Columns.Add("UserId", typeof(int));
            dataTable.Columns.Add("Rating", typeof(double));
            dataTable.Columns.Add("Review", typeof(string));
            dataTable.Columns.Add("IsLike", typeof(bool));

            foreach(var data in products)
            {
                dataTable.Rows.Add(data.ProductId,data.UserId,data.Rating,data.Review,data.IsLike);
            }
            Console.WriteLine("Data Added Successfully");
            return dataTable;
        }

        public static void DisplayRecords(DataTable dataTable)
        {
            var response = (from product in dataTable.AsEnumerable() select product.Field<int>("ProductID"));
            Console.WriteLine("ProductId: ");
            foreach(int product in response)
            {
                Console.WriteLine(product);
            }
        }

    }
}
