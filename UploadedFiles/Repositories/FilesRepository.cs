using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UploadedFiles.Models;

namespace UploadedFiles.Repositories
{
	public class FilesRepository : IFilesRepository
	{
		public List<File> Files { get; set; }

		public FilesRepository()
		{
			Files = new List<File>();
		}

		public IEnumerable<File> getFiles(){
			return Files;
		}

		public File getFile(Guid id)
		{
			return Files.Find(f => f.Id == id);
		}

		public void UpdateFile(Guid id, File file)
		{
			Files.Where(f => f.Id == id).Select(f => {
				f.Name = file.Name;
				f.Size = file.Size;
				f.UploadedDate = file.UploadedDate; 
				return f; 
			}).ToList();
		}
		public void AddFile(File file)
		{
			Files.Add(file);
		}
		public void DeleteFile(Guid id)
		{
			Files.RemoveAll(f => f.Id == id);
		}


	}
}
