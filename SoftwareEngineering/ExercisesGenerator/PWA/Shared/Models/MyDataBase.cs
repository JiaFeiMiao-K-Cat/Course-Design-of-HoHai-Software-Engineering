using IndexedDB.Blazor;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tools;

namespace PWA.Shared.Models
{
    public class MyDataBase : IndexedDb
    {
        public MyDataBase(IJSRuntime jSRuntime, string name, int version)
            : base(jSRuntime, name, version)
        {
        }
        public IndexedSet<WrongProblem> WrongProblems { get; set; }
        public IndexedSet<Statist> Statists { get; set; }
    }
}
