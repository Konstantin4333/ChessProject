using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.ViewModel
{
    public class TestingViewModel
    {
        public int TestingRow { get; set; }
        public int TestingColumn { get; set; }
        
       public TestingViewModel()
        {
            TestingRow = 2;
            TestingColumn = 3 ;
        }
    }
    
}
  