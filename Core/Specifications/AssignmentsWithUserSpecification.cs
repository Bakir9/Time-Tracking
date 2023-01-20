using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class AssignmentsWithUserSpecification : BaseSpecification<Assignment>
    {
        public AssignmentsWithUserSpecification()
        {
            AddInclude(x => x.User);
        }
    }
}