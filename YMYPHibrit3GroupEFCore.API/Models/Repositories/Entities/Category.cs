﻿namespace YMYPHibrit3GroupEFCore.API.Models.Repositories.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public virtual List<Product>? Products { get; set; }
    }
}