using System;


namespace Server.Items
{
	public class VineCord : BaseShoes
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override int BasePhysicalResistance{ get{ return 4; } }
		public override int BaseFireResistance{ get{ return 4; } }
		public override int BaseColdResistance{ get{ return 4; } }
		public override int BasePoisonResistance{ get{ return 4; } }
		public override int BaseEnergyResistance{ get{ return 4; } }
		
		[Constructable]
		public VineCord() : this( 0 )
		{

		}

		[Constructable]
		public VineCord( int hue ) : base( 0x170D, hue )
		{
			Name = "Vine Cord Sandals";
			LootType = LootType.Blessed;
			Weight = 1.0;
		}

		public VineCord( Serial serial ) : base( serial )
		{
		}

		public override bool Dye( Mobile from, DyeTub sender )
		{
			return false;
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