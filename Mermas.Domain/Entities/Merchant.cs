using Mermas.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mermas.Domain.Entities
{
    public class Merchant : AuditableEntity
    {
        private string _title;
        public string Title
        {
            get => _title; set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"'{nameof(Title)}' cannot be null or empty.", nameof(Title));
                }
                _title = value;
            }
        }
        public ICollection<Product> Products { get; set; }
        public IReadOnlyList<Product> AllProducts => Products.ToList();
        public IReadOnlyList<Product> PublishedProducts => Products.Where(m => m.Status == ProductStatuses.OnPublish).ToList();
        public IReadOnlyList<Product> HiddenProducts => Products.Where(m => m.Status == ProductStatuses.OnHidden).ToList();

        public bool IsOwnProduct(Product product) => Products.Any(m => m.Id == product.Id);

        public void IncreaseProductStockQuantity(Product product, int quantity)
        {
            if (!IsOwnProduct(product))
            {
                new InvalidOperationException("Merchant cannot change product quantity that other the product it owns.");
            }
            product.IncreaseStockQuantity(quantity);
        }
        public void DecreaseStockQuantity(Product product, int quantity)
        {
            if (!IsOwnProduct(product))
            {
                new InvalidOperationException("Merchant cannot change product quantity that other the product it owns.");
            }
            product.DecreaseStockQuantity(quantity);
        }

        public Product CreateProduct(string title, string description, int stockQuantity, Category category)
        {
            return new Product(title, description, stockQuantity, category, this);
        }
        public void UpdateProductInfo(Product product, string title, string description)
        {
            product.UpdateInfo(title, description);
        }
        public void SetProductStockQuantity(Product product, int quantity)
        {
            product.SetStockQuantity(quantity);
        }
        public void SetProductCategory(Product product, Category category)
        {
            product.SetCategory(category);
        }
    }

}

