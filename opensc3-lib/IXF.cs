using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace opensc3lib
{
	public class IXF
	{
		#region Fields
		private Dictionary<int, IXFEntry> _entries = new Dictionary<int, IXFEntry>();
		private int _id = 0;
		#endregion

		#region Properties
		/// <summary>
		/// Gets the entries.
		/// </summary>
		/// <value>The entries.</value>
		public Dictionary<int, IXFEntry> Entries {
			get {
				return _entries;
			}
		}

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
				throw new Exception ("The specified file is not an IXF file");


			// entries
			while(true) {
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

				// add entry
				_entries.Add (id, new IXFEntry (id, (IXFEntryType)type, data));

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

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="opensc3lib.IXF"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="opensc3lib.IXF"/>.</returns>
		public override string ToString ()
		{
			// builder
			StringBuilder builder = new StringBuilder ();

			// loop
			foreach (KeyValuePair<int, IXFEntry> kv in _entries) {
				builder.AppendLine (
					"ID: 0x" + kv.Key.ToString ("X4") +
					" Type: " + ((IXFEntryType)kv.Value.Type).ToString() +
					" (0x" + kv.Value.Type.ToString("X") + ")"
				);
			}

			return builder.ToString ();
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="opensc3lib.IXF"/> class.
		/// </summary>
		/// <param name="stream">Stream.</param>
		public IXF(Stream stream) {
			Load (stream);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="opensc3lib.IXF"/> class.
		/// </summary>
		/// <param name="path">Path.</param>
		public IXF(string path) {
			Load (path);
		}
		#endregion
	}

	public class IXFEntry
	{
		#region Fields
		private int _id;
		private byte[] _data;
		private IXFEntryType _type;
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

		/// <summary>
		/// Gets the type.
		/// </summary>
		/// <value>The type.</value>
		public IXFEntryType Type {
			get {
				return _type;
			}
		}
		#endregion

		#region Methods
		/// <summary>
		/// Save this entry to the specified stream.
		/// </summary>
		/// <param name="stream">Stream.</param>
		public void Save(Stream stream) {
			// writer
			BinaryWriter writer = new BinaryWriter (stream);

			// write data
			writer.Write (_data);
		}

		/// <summary>
		/// Save this entry to the specified path.
		/// The appropriate extension will be automatically appended.
		/// </summary>
		/// <param name="path">Path.</param>
		public void Save(string path) {
			// switch for extensions
			switch (_type) {
			case IXFEntryType.Text:
				path += ".txt";
				break;
			}

			// save to stream
			using (FileStream stream = new FileStream (path, FileMode.Create)) {
				Save (stream);
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="opensc3lib.IXFEntry"/> class.
		/// </summary>
		/// <param name="id">Identifier.</param>
		/// <param name="type">Type.</param>
		/// <param name="data">Data.</param>
		public IXFEntry(int id, IXFEntryType type, byte[] data) {
			_id = id;
			_type = type;
			_data = data;
		}
		#endregion
	}

	public enum IXFEntryType : int
	{
		Text = 0x2026960B
	}
}

