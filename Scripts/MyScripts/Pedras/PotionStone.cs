//GM Arthanys - Mystara Shard: www.mystara.com.br

using System;
using Server.Items;
using Server.Gumps;

namespace Server.Items
{
	public class PotionStone : Item
	{
		[Constructable]
		public PotionStone() : base( 0xED4 )
		{
			Movable = false;
			Hue = 1282;
			Name = "a Potion Stone";
		}

		public override void OnDoubleClick( Mobile from )
		{
                  
			from.SendGump (new PotionGump());
		
		   	
					
		}

		public PotionStone( Serial serial ) : base( serial )
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
