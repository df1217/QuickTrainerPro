using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TermProject.Models;

namespace TermProject.Repositories
{
    public class MessageRepository
    {
        private ApplicationDbContext context;

        public MessageRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Message> GetAllMessages()
        {
            return context.Messages.Include(m => m.From).
                Include(m => m.To);
        }

    }
}
