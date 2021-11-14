using Mermas.Domain.Common;
using Mermas.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Mermas.Domain.Entities
{
    public class Category : AuditableEntity, ISoftDelete
    {
        private const int MIN_PRODUCT_STOCK_QUANTITY = 0;
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
        private int _productMinStockQuantity;
        public int ProductMinStockQuantity
        {
            get => _productMinStockQuantity; set
            {
                if (value < MIN_PRODUCT_STOCK_QUANTITY)
                {
                    throw new ArgumentException($"'{nameof(ProductMinStockQuantity)}' cannot be less than {MIN_PRODUCT_STOCK_QUANTITY}.", nameof(ProductMinStockQuantity));
                }
                _productMinStockQuantity = value;
            }
        }
        public List<Product> Products { get; set; }
        public bool IsDeleted { get; private set; }

        public DateTime? DeletionDate { get; private set; }
        public void SoftDelete()
        {
            IsDeleted = true;
            DeletionDate = DateTime.Now;
        }

    }
}
