using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Specifications
{
    public class Specification
    {
        private int _pageSize = 20;
        private int _maxSize = 120;

        public int Page { get; set; } = 1;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > _maxSize ? _maxSize : value;
        }

    }
}
