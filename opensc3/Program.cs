﻿using System;
using opensc3lib;
using System.Collections.Generic;

namespace opensc3
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			DAT file = new DAT ("Res/Sprites/0000000A_Landmarks.DAT");
			//PAK file = new PAK ("Sys/SYS.PAK");



			// ixf extract
			/*foreach(KeyValuePair<int, IXFEntry> kv in file.Entries) {
				kv.Value.Save ("out2/" + kv.Key.ToString("X4") + ".dat");
			}*/

			// sys pak extract
			/*foreach (KeyValuePair<string, PAKEntry> kv in file.Entries) {
				kv.Value.Save ("out/" + kv.Key + ".ini");
			}*/
		}
	}
}
