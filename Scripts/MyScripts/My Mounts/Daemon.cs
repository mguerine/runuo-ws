// Edited by: Mark Ribeiro

using System; 
using Server.Mobiles; 

namespace Server.Items 
{ 
	public class EtherealDemon : EtherealMount 
	{ 

		[Constructable] 
		public EtherealDemon() : base( 11670, 0x3E91 )                            
		{ 
			Name = "Ethereal Demon Statuette";
			ItemID = 8403;
			MountedID = 16239;
			RegularID = 8403;
			LootType = LootType.Blessed; 
		} 

		public EtherealDemon( Serial serial ) : base( serial ) 
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

			if ( Name != "Ethereal Demon Statuette" )
				Name = "Ethereal Demon Statuette";
		} 
	}
}

