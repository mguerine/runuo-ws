//GM Arthanys - Mystara Shard: www.mystara.com.br

using System;
using Server.Items;
using Server.Gumps;
using Server.Accounting;

namespace Server.Items
{
	public class FirstStone : Item
	{
		[Constructable]
		public FirstStone() : base( 0xED4 )
		{
			Movable = false;
			Hue = 1288;
			Name = "HOW TO PLAY";
		}

		public override void OnDoubleClick( Mobile from )
		{
                  
			from.SendGump (new FirstGump());
		
		   	
					
		}

		public FirstStone( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
