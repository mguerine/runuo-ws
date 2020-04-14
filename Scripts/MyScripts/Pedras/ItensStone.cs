//GM Arthanys - Mystara Shard: www.mystara.com.br

using System;
using Server.Items;
using Server.Gumps;

namespace Server.Items
{
	public class ItensStone : Item
	{
		[Constructable]
		public ItensStone() : base( 0xED4 )
		{
			Movable = false;
			Hue = 1965;
			Name = "a Itens Stone";
		}

		public override void OnDoubleClick( Mobile from )
		{
                  
			from.SendGump (new ItensGump());
		
		   	
					
		}

		public ItensStone( Serial serial ) : base( serial )
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
