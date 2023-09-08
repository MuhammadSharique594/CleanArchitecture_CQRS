using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MicroservicesAndDockerContainer.Commands
{
    public record MicroservicesAndDockerContainerCommand(
                                                            string description, 
                                                            string furtherDescription
                                                        ) : IRequest<MicroservicesAndDockerContainerCommand> ;
}
