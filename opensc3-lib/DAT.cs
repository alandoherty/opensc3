using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace opensc3lib
{
	public class DAT
	{
		#region Fields
		private int _id;
		#endregion

		#region Properties
		/// <summary>
		/// Gets the ID.
		/// </summary>
		/// <value>The ID.</value>
		public int ID {
			get {
				return _id;
			}
		}
		#endregion

		#region Methods
		/// <summary>
		/// Load from the specified stream.
		/// </summary>
		/// <param name="stream">Stream.</param>
		private void Load(Stream stream) {
			// reader
			BinaryReader reader = new BinaryReader (stream);

			// identity
			if (reader.ReadUInt32 () != 0x80C381D7)
				throw new Exception ("The specified file is not an DAT file");

			// entries
			while (true) {
				// read entry
				_id = reader.ReadInt32 (); // "directory id"
				int id = reader.ReadInt32 (); // id
				int type = reader.ReadInt32 (); // type
				int offset = reader.ReadInt32 ();
				int length = reader.ReadInt32 ();

				// check if end
				if (id == 0)
					break;

				// store current position
				long curPos = reader.BaseStream.Position;

				// seek to new position
				reader.BaseStream.Seek (offset, SeekOrigin.Begin);

				// read data
				byte[] data = reader.ReadBytes (length);

				// write
				File.WriteAllBytes ("out2/" + id.ToString ("X4") + "-" + type.ToString() + ".dat", data);

				// seek to old position
				reader.BaseStream.Seek (curPos, SeekOrigin.Begin);
			}
		}

		/// <summary>
		/// Load from the specified path.
		/// </summary>
		/// <param name="path">Path.</param>
		private void Load(string path) {
			using (FileStream stream = new FileStream (path, FileMode.Open)) {
				Load (stream);
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="opensc3lib.DAT"/> class.
		/// </summary>
		/// <param name="stream">Stream.</param>
		public DAT(Stream stream) {
			Load (stream);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="opensc3lib.DAT"/> class.
		/// </summary>
		/// <param name="path">Path.</param>
		public DAT(string path) {
			Load (path);
		}
		#endregion
	}
}

