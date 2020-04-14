//GM Arthanys - Mystara Shard: www.mystara.com.br

using System;
using Server.Items;
using Server.Gumps;
using Server.Accounting;

namespace Server.Items
{
	public class SkinStone : Item
	{
		[Constructable]
		public SkinStone() : base( 0xED4 )
		{
			Movable = false;
			Hue = 1964;
			Name = "a Skin Stone";
		}

		public override void OnDoubleClick( Mobile from )
		{
                  
			from.SendGump (new SkinGump());
		
		   	
					
		}

		public SkinStone( Serial serial ) : base( serial )
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
