using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Getting_Real;
using System.Collections.Generic;

namespace Getting_Real_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddSupplierToDatabase()
        {
            DatabaseAccess databaseAccess = new DatabaseAccess();
            databaseAccess.ClearSupplierAndZipTables();

            Supplier newSupplier = new Supplier()
            {
                SupplierName = "Steve",
                SupplierCompany = "Samsung",
                Email = "samsung@gmail.com",
                PhoneNumber = "123456789",
                Address = "Seebladsgade 1",
                City = "Odense",
                Country = "Denmark",
                Zip = 65478
            };

            if (databaseAccess.DoesZipExist(newSupplier.Zip) == false)
            {
                databaseAccess.AddNewZipNumberToTable(newSupplier.Zip);
            }

            databaseAccess.AddNewSupplierToTable(newSupplier);
            List<Supplier> listOfSuppliers = databaseAccess.GetListOfSuppliers();
            Assert.IsTrue(listOfSuppliers.Count == 1);

            bool doesSupplierExist = false;

            foreach (Supplier supplier in listOfSuppliers)
            {
                if (
                    supplier.SupplierName == newSupplier.SupplierName
                    && supplier.SupplierCompany == newSupplier.SupplierCompany
                    && supplier.Email == newSupplier.Email
                    && supplier.PhoneNumber == newSupplier.PhoneNumber
                    && supplier.Address == newSupplier.Address
                    && supplier.City == newSupplier.City
                    && supplier.Country == newSupplier.Country
                    && supplier.Zip == newSupplier.Zip)
                {
                    doesSupplierExist = true;
                }
            }
            Assert.IsTrue(doesSupplierExist);
        }


        [TestMethod]
        public void AddCategoryToDatabase()
        {
            DatabaseAccess databaseAccess = new DatabaseAccess();
            Category newCategory = new Category()
            {
                CategoryName = "TestCategory"
            };

            databaseAccess.ClearProductTable();
            databaseAccess.ClearCategoryTable();
            databaseAccess.AddNewCategoryToTable(newCategory);
            List<Category> listOfCategories = databaseAccess.GetListOfCategories();

            bool doesCategoryExist = false;

            foreach (Category category in listOfCategories)
            {
                if (category.CategoryName == newCategory.CategoryName)
                {
                    doesCategoryExist = true;
                }
            }
            Assert.IsTrue(doesCategoryExist);
        }

        [TestMethod]

        public void AddProductWithoutSupplierToDatabase()
        {
            DatabaseAccess databaseAccess = new DatabaseAccess();
            databaseAccess.ClearProductTable();
            databaseAccess.ClearCategoryTable();

            Category newCategory = new Category()
            {
                CategoryName = "TestCategory"
            };

            databaseAccess.AddNewCategoryToTable(newCategory);
            List<Category> listOfCategories = databaseAccess.GetListOfCategories();

            Category loadedCategory = listOfCategories[0];
            int CategoryID = loadedCategory.CategoryID;

            Product newProduct = new Product()
            {
                ProductName = "ProductName",
                CategoryID = CategoryID,
                ProductAmount = 10,
                ProductDescription = "Brand New Product",
                ProductPrice = 25
            };

            databaseAccess.AddNewProductToTable(newProduct);
            List<Product> listOfProducts;
            listOfProducts = databaseAccess.GetListOfProducts();

            bool doesProductExist = false;

            foreach (Product product in listOfProducts)
            {
                if
                    (
                    newProduct.ProductName == product.ProductName
                    && newProduct.CategoryID == product.CategoryID
                    && newProduct.ProductAmount == product.ProductAmount
                    && newProduct.ProductDescription == product.ProductDescription
                    && newProduct.ProductPrice == product.ProductPrice
                    && newProduct.SupplierID == product.SupplierID
                    )
                {
                    doesProductExist = true;
                }
            }
            Assert.IsTrue(doesProductExist);
        }
        [TestMethod]
        public void SearchForSuppliers()
        {
            DatabaseAccess databaseAccess = new DatabaseAccess();
            databaseAccess.ClearSupplierAndZipTables();

            List<Supplier> suppliersToAdd = new List<Supplier>();

            Supplier firstSupplier = new Supplier()
            {
                SupplierName = "Steve",
                SupplierCompany = "Samsung",
                Email = "samsung@gmail.com",
                PhoneNumber = "123456789",
                Address = "Seebladsgade 1",
                City = "Odense",
                Country = "Denmark",
                Zip = 65478
            };
            suppliersToAdd.Add(firstSupplier);


            Supplier secondSupplier = new Supplier()
            {
                SupplierName = "Simon",
                SupplierCompany = "Samsung",
                Email = "samsung@gmail.com",
                PhoneNumber = "123456789",
                Address = "Seebladsgade 1",
                City = "Odense",
                Country = "Denmark",
                Zip = 6548
            };
            suppliersToAdd.Add(secondSupplier);


            Supplier thirdSupplier = new Supplier()
            {
                SupplierName = "Anna",
                SupplierCompany = "Samsung",
                Email = "samsung@gmail.com",
                PhoneNumber = "123456789",
                Address = "Seebladsgade 1",
                City = "Odense",
                Country = "Denmark",
                Zip = 6478
            };
            suppliersToAdd.Add(thirdSupplier);//adds to list


            foreach (Supplier supplier in suppliersToAdd)
            {
                if (databaseAccess.DoesZipExist(supplier.Zip) == false)
                {
                    databaseAccess.AddNewZipNumberToTable(supplier.Zip);
                }
                databaseAccess.AddNewSupplierToTable(supplier); // adds to supplier



            }

            List<Supplier> ListOfSuppliers = databaseAccess.GetListOfFoundSuppliers("Ste");

            bool doesSupplierExist = false;
            foreach (Supplier supplier in ListOfSuppliers)
            {
                if (
                    supplier.SupplierName == suppliersToAdd[0].SupplierName
                    && supplier.SupplierCompany == suppliersToAdd[0].SupplierCompany
                    && supplier.Email == suppliersToAdd[0].Email
                    && supplier.PhoneNumber == suppliersToAdd[0].PhoneNumber
                    && supplier.Address == suppliersToAdd[0].Address
                    && supplier.City == suppliersToAdd[0].City
                    && supplier.Country == suppliersToAdd[0].Country
                    && supplier.Zip == suppliersToAdd[0].Zip)
                {
                    doesSupplierExist = true;
                }
            }
            Assert.IsTrue(doesSupplierExist);
        }
    }
}

