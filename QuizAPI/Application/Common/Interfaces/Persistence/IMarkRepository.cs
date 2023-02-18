using Domain.MarkAggregate;
using Domain.MarkAggregate.ValueObjects;
using Domain.PasserAggregate.ValueObjects;
using Domain.QuizAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Persistence
{
    public interface IMarkRepository
    {
        Task<Mark> AddAsync(Mark mark);
        Task<Mark?> GetAsync(QuizId quizId, PasserId passerId);
        Task RemoveAsync(Mark mark);
    }
}
