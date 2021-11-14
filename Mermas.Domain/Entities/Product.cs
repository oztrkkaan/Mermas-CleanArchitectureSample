using Mermas.Domain.Common;
using Mermas.Domain.Interfaces;
using System;

namespace Mermas.Domain.Entities
{
    public class Product : AuditableEntity, ISoftDelete
    {
        public Product(string title, string description, int stockQuantity, Category category, Merchant merchant)
        {
            Title = title;
            Description = description;
            Category = category;
            Merchant = merchant;
            StockQuantity = stockQuantity;
        }
        public Product()
        {
        }
        private string _title;
        public string Title
        {
            get => _title;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"'{nameof(Title)}' cannot be null or empty.", nameof(Title));
                }
                _title = value;
            }
        }
        public string Description { get; private set; }
        public Category Category { get; private set; }
        public Merchant Merchant { get; private set; }
        public ProductStatuses Status { get; private set; } = ProductStatuses.OnPublish;
        private int _stockQuantity;
        public int StockQuantity
        {
            get => _stockQuantity;
            private set
            {
                if (value < Category.ProductMinStockQuantity)
                {
                    throw new ArgumentException($"Product stock quantity cannot be less than category minimum product stock quantity.", nameof(StockQuantity));
                }
                _stockQuantity = value;
            }
        }

        public bool IsDeleted { get; private set; }

        public DateTime? DeletionDate { get; private set; }
        public void SoftDelete()
        {
            IsDeleted = true;
            DeletionDate = DateTime.Now;
        }




        public void UpdateInfo(string title, string description)
        {
            Title = title;
            Description = description;
        }
        public void IncreaseStockQuantity(int quantity)
        {
            StockQuantity += quantity;
        }
        public void DecreaseStockQuantity(int quantity)
        {
            StockQuantity += quantity * -1;
        }

        public void SetStockQuantity(int quantity)
        {
            if (quantity < Category.ProductMinStockQuantity)
            {
                new ArgumentException($"Decreased quantity cannot be less than {Category.ProductMinStockQuantity}");
            }
            StockQuantity = quantity;
        }


    }

    public enum ProductStatuses
    {
        OnHidden,
        OnPublish,
    }
}
