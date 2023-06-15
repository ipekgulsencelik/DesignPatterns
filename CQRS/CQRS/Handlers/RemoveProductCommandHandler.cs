﻿using CQRS.CQRS.Commands;
using CQRS.DAL;

namespace CQRS.CQRS.Handlers
{
    public class RemoveProductCommandHandler
    {
        private readonly Context _context;

        public RemoveProductCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(RemoveProductCommand command)
        {
            var values = _context.Products.Find(command.ID);
            _context.Products.Remove(values);
            _context.SaveChanges();
        }
    }
}
