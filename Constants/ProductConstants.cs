﻿using JWT.Web.Api.Models;

namespace JWT.Web.Api.Constants
{
    public class ProductConstants
    {

        public static List<ProductModel> Products = new List<ProductModel>()
        {
            new ProductModel() { Name = "Coca Cola", Description = "Bebida con gas" },
            new ProductModel() { Name = "Agua Villavicencio", Description = "Agua mineral de 2L" },
        };
    }
}
