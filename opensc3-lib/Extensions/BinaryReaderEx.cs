using System;
using System.IO;
using System.Text;

namespace opensc3lib.Extensions
{
	public static class BinaryReaderEx
	{
		#region Extension Methods
		/// <summary>
		/// Reads the PAK formatted string.
		/// </summary>
		/// <returns>The pak string.</returns>
		/// <param name="reader">Reader.</param>
		public static string ReadPakString(this BinaryReader reader) {
			// length
			int length = reader.ReadInt32 ();

			// characters
			char[] chars = Encoding.ASCII.GetChars(reader.ReadBytes (length));

			return new string (chars);
		}
		#endregion
	}
}

