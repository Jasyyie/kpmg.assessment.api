using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MediatR;
using System.Reflection;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace kpmg.assessment.api.commands
{
    public class DogSearchRequest : IRequest<DogSearchResponse>
    {

    }
}