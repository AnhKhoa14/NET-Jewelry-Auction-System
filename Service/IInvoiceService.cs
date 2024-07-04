﻿using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IInvoiceService
    {
        public List<Invoice> GetAllInvoices();
        public Invoice GetInvoiceById(int id);
        public void CreateInvoice(Invoice Invoice);
        public void UpdateInvoice(Invoice Invoice);
        public void DeleteInvoice(Invoice Invoice);
    }
}
