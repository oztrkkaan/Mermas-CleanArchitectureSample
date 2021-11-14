using Mermas.Domain.Common;
using Mermas.Domain.Interfaces;
using System;

namespace Mermas.Domain.Entities
{
    public class Product : AuditableEntity, ISoftDelete
    {
        private string _title;
        public string Title
        {
            get => _title; 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"'{nameof(Title)}' cannot be null or empty.", nameof(Title));
                }
                _title = value;
            }
        }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Merchant Merchant { get; set; }
        public ProductStatuses Status { get; set; } = ProductStatuses.OnPublish;
        private int _stockQuantity;
        public int StockQuantity
        {
            get => _stockQuantity;
            set
            {
                if (value < Category.ProductMinStockQuantity)
                {
                    throw new ArgumentException($"Product stock quantity cannot be less than category minimum product stock quantity.", nameof(StockQuantity));
                }
                _stockQuantity = value;
            }
        }
        private bool _isDeleted;

        public bool IsDeleted
        {
            get { return _isDeleted; }
            set
            {
                DeletionDate = value ? DateTime.Now : null;
                _isDeleted = value;
            }
        }
        public DateTime? DeletionDate { get; private set; }
        public void IncreaseStockQuantity(int quantity)
        {
            if (quantity < Category.ProductMinStockQuantity)
            {
                new ArgumentException($"Increased quantity cannot be less than {Category.ProductMinStockQuantity}");
            }
            StockQuantity += quantity;
        }
        public void DecreaseStockQuantity(int quantity)
        {
            if (quantity < Category.ProductMinStockQuantity)
            {
                new ArgumentException($"Decreased quantity cannot be less than {Category.ProductMinStockQuantity}");
            }
            StockQuantity += quantity * -1;
        }
    }

    public enum ProductStatuses
    {
        OnHidden,
        OnPublish,
    }
}
