using System;
using System.Reflection;

using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

namespace RazorPagesTest
{
	internal class MyEmbeddedFileProvider : IFileProvider
	{
		protected String _RequestPath;
		protected IFileProvider _Provider;

		public MyEmbeddedFileProvider(Assembly lib, String requestPath = null)
		{
			this._Provider = new PhysicalFileProvider("C:\\Projects\\RazorPagesTest\\RazorPagesTestViews");
			this._RequestPath = $"{requestPath}/Views/";
		}

		public IDirectoryContents GetDirectoryContents(String subpath)
		{
			var contents = this._Provider.GetDirectoryContents(subpath);

			return contents;
		}

		public IFileInfo GetFileInfo(String subpath)
		{
			var contents = this._Provider.GetFileInfo(subpath.Substring(this._RequestPath.Length - 1));

			return contents;
		}

		public IChangeToken Watch(String filter)
		{
			var token = this._Provider.Watch(filter);

			return token;
		}
	}
}