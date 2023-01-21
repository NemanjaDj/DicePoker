using System;
using System.Collections.Generic;
using System.Text;

namespace DicePoker.Domain.ViewModels
{
    class HandViewModel
    {
        public int Id { get; set; }
        public List<int> Numbers { get; set; }
        public bool IsActive { get; set; }
    }
}
