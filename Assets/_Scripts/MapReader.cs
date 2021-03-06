﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;

public class MapReader {

	static string mainDir = System.IO.Directory.GetCurrentDirectory();
	static string mapDir = mainDir + "\\Assets\\Resources\\Maps\\";

	public static bool LoadMap(Map whichMap, string fileName)
	{
		if (whichMap == null) {
			return false;
		}

		fileName = mapDir + fileName;

		// Handle any problems that might arise when reading the text
		try
		{
			string line;
			// Create a new StreamReader, tell it which file to read and what encoding the file
			// was saved as
			StreamReader theReader = new StreamReader(fileName, Encoding.Default);
			// Immediately clean up the reader after this block of code is done.
			// You generally use the "using" statement for potentially memory-intensive objects
			// instead of relying on garbage collection.
			// (Do not confuse this with the using directive for namespace at the 
			// beginning of a class!)

			using (theReader)
			{
				// While there's lines left in the text file, do this:
				do
				{
					line = theReader.ReadLine();
					if (line != null)
					{
						// Do whatever you need to do with the text line, it's a string now
						// In this example, I split it into arguments based on comma
						// deliniators, then send that array to DoStuff()

						string[] entries = line.Split(',');
						float[] data = new float[entries.Length];

						if (entries.Length > 0) {

							for (int i = 0; i < entries.Length; i++) {
								data[i] = float.Parse(entries[i]);
							}

							whichMap.addTile(data);
						}
					}
				} 
				while (line != null);

				// Done reading, close the reader and return true to broadcast success    
				theReader.Close();
				return true;
			}
		}
		// If anything broke in the try block, we throw an exception with information
		// on what didn't work
		catch (Exception e)
		{
			MonoBehaviour.print(e.Message);
			return false;
		}
	}
}

