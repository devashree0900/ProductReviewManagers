using System;
using System.Data;

namespace ProductReviewManagers
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<ProductReview> products = new List<ProductReview>();
            ProductReviewManager.AddProductReviewToList(products);
            //ProductReviewManager.IterateList(products);
            //ProductReviewManager.RetrieveTopThree(products);
            //ProductReviewManager.RetrieveParticularData(products);
            //ProductReviewManager.RetrieveProductReviewCount(products);
            //ProductReviewManager.SkipTopThree(products);
            DataTable dt = ProductReviewManager.CreateTable(products);
            ProductReviewManager.DisplayRecords(dt);
        }
    }
}
