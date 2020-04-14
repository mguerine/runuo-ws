//GM Arthanys - Mystara Shard: www.mystara.com.br

using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Accounting;

namespace Server.Items
{
	public class BagofRunica : Bag
	{
		

		[Constructable]
		public BagofRunica()
		{
			
			DropItem( new RunicHammer( CraftResource.Verite, 999 ) );
			DropItem( new RunicHammer( CraftResource.Valorite, 999 ) );
			DropItem( new RunicSewingKit( CraftResource.HornedLeather, 999 ) );
			DropItem( new RunicSewingKit( CraftResource.BarbedLeather, 999 ) );

		}

		public BagofRunica( Serial serial ) : base( serial )
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