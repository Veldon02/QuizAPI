using Application.Common.Interfaces.Persistence;
using Domain.MarkAggregate;
using Domain.PasserAggregate.ValueObjects;
using Domain.QuizAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class MarkRepository : IMarkRepository
    {
        private readonly QuizDbContext _context;

        public MarkRepository(QuizDbContext context)
        {
            _context = context;
        }
        public async Task<Mark> AddAsync(Mark mark)
        {
            await _context.Marks.AddAsync(mark);
            await _context.SaveChangesAsync();
            return mark;
        }

        public async Task<Mark?> GetAsync(QuizId quizId, PasserId passerId)
        {
            return await _context.Marks.FirstOrDefaultAsync(x => x.PasserId == passerId && x.QuizId == quizId);
        }

        public async Task RemoveAsync(Mark mark)
        {
            _context.Marks.Remove(mark);
            await _context.SaveChangesAsync();
        }
    }
}
