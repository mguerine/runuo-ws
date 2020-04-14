// Edited by: Mark Ribeiro

using System; 
using Server.Mobiles; 

namespace Server.Items 
{ 
	public class EtherealPolarBear : EtherealMount 
	{ 
		[Constructable] 
		public EtherealPolarBear() : base( 11676, 0x3E92 ) 
		{ 
			Name = "Ehereal Polar Bear";
			ItemID = 8417;
			MountedID = 16069;
			RegularID = 8417;
			LootType = LootType.Blessed;
		} 

		public EtherealPolarBear( Serial serial ) : base( serial ) 
		{ 
		} 

		

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 

			writer.Write( (int) 0 ); 
		} 

		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 

			int version = reader.ReadInt(); 

			if ( Name != "Ethereal Polar Bear" )
				Name = "Ethereal Polar Bear";
		} 
	}
}
