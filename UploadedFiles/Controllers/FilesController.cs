using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UploadedFiles.Models;
using UploadedFiles.Repositories;

namespace FileUploeader.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FilesController : ControllerBase
	{
		private IFilesRepository _filesRepository;

		public FilesController(IFilesRepository filesRepository)
		{
			_filesRepository = filesRepository;
		}

		[HttpGet]
		public ActionResult<IEnumerable<File>> GetFiles()
		{
			var files = _filesRepository.getFiles();
			if (files == null || !files.Any())
			{
				return NotFound();
			}
			return Ok(files);
		}

		[HttpGet("{id}")]
		public ActionResult<File> GetFile(Guid id)
		{
			var file = _filesRepository.getFile(id);

			if (file == null)
			{
				return NotFound();
			}
			return Ok(file);
		}



		[HttpPost]
		public ActionResult<File> PostFile(File file)
		{
			_filesRepository.AddFile(file);

			return CreatedAtAction("GetFiles", new { id = file.Id }, file);
		}

		[HttpDelete]
		public ActionResult<File> DeleteFile(Guid id)
		{
			var file = _filesRepository.getFile(id);

			if (file == null)
			{
				return NotFound();
			}
			_filesRepository.DeleteFile(id);

			return Ok();
		}

		[HttpPut("{id}")]
		public ActionResult PutFile(Guid id, File file)
		{
			if(id != file.Id)
			{
				return BadRequest();
			}
			_filesRepository.UpdateFile(id,file);

			return Ok();
		}
	}
}
