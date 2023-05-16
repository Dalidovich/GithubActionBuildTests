using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubActionBuildTests.Domain.Models
{
    public class SummaryCalc
    {
        public Guid? Id { get; set; }
        public string MethodName { get; set; }
        public int FirstNum { get; set; }
        public int SecondNum { get; set; }

        public SummaryCalc()
        {
        }

        public SummaryCalc(string methodName, int firstNum, int secondNum)
        {
            Id = null;
            MethodName = methodName;
            FirstNum = firstNum;
            SecondNum = secondNum;
        }

    }
}
