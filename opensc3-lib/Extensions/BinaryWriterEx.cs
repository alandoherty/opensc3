using System;
using System.IO;
using System.Text;

namespace opensc3lib
{
	public static class BinaryWriterEx
	{
		#region Extension Methods
		/// <summary>
		/// Writes the PAK string.
		/// </summary>
		/// <param name="writer">Writer.</param>
		/// <param name="str">String.</param>
		public static void WritePakString(this BinaryWriter writer, string str) {
			// length
			writer.Write (str.Length);

			// characters
			writer.Write (Encoding.ASCII.GetBytes (str));
		}
		#endregion
	}
}

