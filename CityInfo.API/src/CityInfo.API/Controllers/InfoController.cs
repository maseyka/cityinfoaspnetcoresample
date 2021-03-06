﻿using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace CityInfo.API.Controllers
{
	[Route("api/info")]
	public class InfoController : Controller
    {
		[HttpGet]
		public IActionResult GetAssembyInformaion()
		{
			dynamic assemblyInformation = new ExpandoObject();
			var assembly = typeof(Startup).GetTypeInfo().Assembly;

			assemblyInformation.AssemblyInformationalVersion = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
					.InformationalVersion;

			assemblyInformation.AssemblyVersion = assembly.GetName().Version.ToString();

			assemblyInformation.AssemblyFileVersion = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>()
					.Version;

			return Ok(assemblyInformation);
		}
    }
}
