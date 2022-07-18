using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UploadedFiles.Models;

namespace UploadedFiles.Repository
{
	public interface IFilesRepository
	{

		IEnumerable<File> getFiles();
		File getFile(Guid id);
		void UpdateFile(Guid id, File file);
		void AddFile(File file);
		void DeleteFile(Guid id);
 	}
}
