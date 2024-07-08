﻿using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        public void CreateInvoice(Invoice Invoice)
        {
            InvoiceDAO.CreateInvoice(Invoice);
        }

        public void DeleteInvoice(Invoice Invoice)
        {
            InvoiceDAO.DeleteInvoice(Invoice);
        }

        public List<Invoice> GetAllInvoices()
        {
            return InvoiceDAO.GetAllInvoices();
        }

        public Invoice GetInvoiceById(int id)
        {
            return InvoiceDAO.GetInvoiceById(id);
        }

		public Invoice GetInvoiceByUserId(int id)
		{
			return InvoiceDAO.GetInvoiceByUserId(id);
		}

		public void UpdateInvoice(Invoice Invoice)
        {
            InvoiceDAO.UpdateInvoice(Invoice);
        }
    }
}
