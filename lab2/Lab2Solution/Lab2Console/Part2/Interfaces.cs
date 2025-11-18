using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Console.Part2
{
    public interface IWorker { string Company { get; set; } void Work(); }
    public interface ILearner { string Institution { get; set; } void Study(); }
}
