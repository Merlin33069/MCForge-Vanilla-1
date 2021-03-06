﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using McForge;

namespace CommandDll
{
	public class CmdDataPassExample : ICommand
	{
		string _Name = "DataPassExample";
		public string Name { get { return _Name; } }

		CommandTypes _Type = CommandTypes.misc;
		public CommandTypes Type { get { return _Type; } }

		string _Author = "Merlin33069";
		public string Author { get { return _Author; } }

		int _Version = 1;
		public int Version { get { return _Version; } }

		string _CUD = "";
		public string CUD { get { return _CUD; } }

		string[] CommandStrings = new string[1] { "example" };

		public void Use(Player p, string[] args)
		{
			p.SendMessage("Please place a block...");
			p.CatchNextBlockchange(new Player.BlockChangeDelegate(CatchBlock), null);
		}
		public void CatchBlock(Player p, ushort x, ushort z, ushort y, byte NewType, bool placed, object DataPass)
		{
			Point3 FirstBlock = new Point3(x, z, y);
			p.SendMessage("Please place another block...");
			p.CatchNextBlockchange(new Player.BlockChangeDelegate(CatchBlock2), (object)FirstBlock);
		}
		public void CatchBlock2(Player p, ushort x, ushort z, ushort y, byte NewType, bool placed, object DataPass)
		{
			Point3 FirstBlock = (Point3)DataPass;
			Point3 SecondBlock = new Point3(x, z, y);
			p.SendMessage("This is where we would initiate a Cuboid!");
		}

		public void Help(Player p)
		{

		}

		public void Initialize()
		{
			Command.AddReference(this, CommandStrings);
		}
	}
}
