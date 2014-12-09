using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using opensc3lib.Extensions;

namespace opensc3lib
{
	public class PAK
	{
		#region Fields
		private Dictionary<string, PAKEntry> _entries = new Dictionary<string, PAKEntry>();
		#endregion

		#region Properties
		/// <summary>
		/// Gets the entries.
		/// </summary>
		/// <value>The entries.</value>
		public Dictionary<string,PAKEntry> Entries {
			get {
				return _entries;
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

			// entries
			int countEntries = reader.ReadInt32 ();

			for (int i = 0; i < countEntries; i++) {
				// read entry
				string name = reader.ReadPakString ();
				int offset = reader.ReadInt32 ();

				// store current position
				long curPos = reader.BaseStream.Position;

				// seek to new position
				reader.BaseStream.Seek (offset, SeekOrigin.Begin);

				// read values
				int countValues = reader.ReadInt32 ();
				string[] values = new string[countValues];

				for (int j = 0; j < countValues; j++)
					values[j] = reader.ReadPakString();

				_entries.Add(name, new PAKEntry(values));

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
		/// Save the specified stream.
		/// </summary>
		/// <param name="stream">Stream.</param>
		public void Save(Stream stream) {
			// writer
			BinaryWriter writer = new BinaryWriter (stream);

			// entries
			writer.Write (_entries.Count);

			// entries offset locations
			Dictionary<string, int> offsetLocs = new Dictionary<string, int> ();

			foreach (KeyValuePair<string, PAKEntry> kv in _entries) {
				// write name
				writer.WritePakString (kv.Key);

				// store location
				offsetLocs [kv.Key] = (int)stream.Position;

				// empty offset
				writer.Write (0);
			}

			// entries data
			foreach (KeyValuePair<string, PAKEntry> kv in _entries) {
				// store old location
				int dataStart = (int)stream.Position;

				// goto offset location
				stream.Seek ((int)offsetLocs [kv.Key], SeekOrigin.Begin);

				// write offset
				writer.Write (dataStart);

				// go back to data
				stream.Seek (dataStart, SeekOrigin.Begin);

				// write data
				writer.Write (kv.Value.Values.Count);

				foreach (string str in kv.Value.Values) {
					writer.WritePakString (str);
				}
			}
		}

		/// <summary>
		/// Save the specified path.
		/// </summary>
		/// <param name="path">Path.</param>
		public void Save(string path) {
			using (FileStream stream = new FileStream (path, FileMode.Create)) {
				Save (stream);
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="opensc3lib.PAK"/> class from the specified path.
		/// </summary>
		/// <param name="stream">Stream.</param>
		public PAK(Stream stream) {
			Load (stream);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="opensc3lib.PAK"/> class from the specified path.
		/// </summary>
		/// <param name="path">Path.</param>
		public PAK(string path) {
			Load (path);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="opensc3lib.PAK"/> class.
		/// </summary>
		public PAK()
		{ }
		#endregion
	}

	public class PAKEntry
	{
		#region Fields
		private List<string> _values;
		#endregion

		#region Properties
		/// <summary>
		/// Gets the values.
		/// </summary>
		/// <value>The values.</value>
		public List<string> Values {
			get {
				return _values;
			}
		}
		#endregion

		#region Methods
		/// <summary>
		/// Export this INI entry to the specified stream.
		/// </summary>
		/// <param name="stream">Stream.</param>
		public void Export(Stream stream) {
			// writer
			StreamWriter writer = new StreamWriter (stream);

			// write each value seperated by a new line
			foreach (string val in _values)
				writer.WriteLine (val);

			writer.Flush ();
		}

		/// <summary>
		/// Export this INI entry to the specified path.
		/// </summary>
		/// <param name="path">Path.</param>
		public void Export(string path) {
			// save to stream
			using (FileStream stream = new FileStream (path, FileMode.Create)) {
				Export (stream);
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="opensc3lib.PAKEntry"/> class.
		/// </summary>
		/// <param name="values">Values.</param>
		public PAKEntry(string[] values) {
			_values = new List<string> (values);
		}
		#endregion
	}
}

