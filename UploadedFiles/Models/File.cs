using System;

namespace UploadedFiles.Models
{
	public class File
	{
		public Guid Id { get; set; }
		public string Name { get; set; }

		public int Size { get; set; }

		public DateTime UploadedDate { get; set; }

		public File()
		{
			Id = Guid.NewGuid();
		}
	}

}
