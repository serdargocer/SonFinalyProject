using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

ProductTest();

//CategoryTest();


static void ProductTest()
{

    //ProductManager productManager = new ProductManager(new EfProductDal());
    //var result = productManager.GetProductDetails();
    //if (result.Success == true)
    //{
    //    foreach (var products in result.Data)
    //    {
    //        Console.WriteLine(products.ProductName + " => " + products.CategoryName);

    //    }
    //    Console.WriteLine(Messages.ProductListed);
    //}
    //else
    //{
    //    Console.WriteLine(result.Message);
    //}

    //var result = productManager.GetAll();
    //if (result.Success == true)
    //{
    //    Console.WriteLine(Messages.ProductListed);
    //    foreach (var pro in result.Data)
    //    {
    //        Console.WriteLine(pro.ProductId + "-------" + pro.ProductName + "-------" + pro.UnitsInStock);
    //    }

    //}
    //else
    //{
    //    Console.WriteLine(Messages.MaintenanceTime);

    //}
}



//static void CategoryTest()
//{
//    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
//    //foreach (var category in categoryManager.GetAll())
//    //{
//    //    Console.WriteLine(category.CategoryName);
//    //}

//    foreach (var category in categoryManager.GetCategoryDetails())
//    {
//        Console.WriteLine(category.CategoryId + " => " +category.CategoryName + " => " +category.ProductId + " => " +category.ProductName);
//    }
//}