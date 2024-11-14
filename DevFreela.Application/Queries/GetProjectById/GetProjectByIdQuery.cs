using DevFreela.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetProjectById
{
    public class GetProjectByIdQuery : IRequest<ResultViewModel<ProjectItemViewModel>>
    {
        public GetProjectByIdQuery(int id)
        {
            id = id;
        }

        public int Id { get; set; }
    }
}
